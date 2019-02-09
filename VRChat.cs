using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;

namespace VRCEX
{
    public enum ApiMethod
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public class ApiResult
    {
        public string message;
        public int status_code;
    }

    public class ApiResponse
    {
        public ApiResult error;
        public ApiResult success;
    }

    //
    // VRChat
    //

    // 2018-11-07
    // https://vrchat.net/api/1/youtube
    // https://api.vrchat.cloud/api/1/youtube
    // 138.197.0.101, 138.197.1.206, 138.197.99.115
    // 159.89.32.95, 159.203.172.3, 159.203.173.149

    // To change display name:
    // https://vrchat.net/api/1/auth/exists?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26&username=&displayName=dildo
    // $.ajax({ url: window.endpoint + '/api/1/users/usr_75efc1e5-700f-447b-9beb-11acd9c3f2a9', type: 'PUT', data: {displayName: 'SmartHE'}, succcess: console.log, error: console.log });

    public static class VRCApi
    {
        private static readonly string API_URL = "https://vrchat.net/api/1/";
        private static readonly string COOKIE_FILE_NAME = "cookie.dat";
        private static string m_ApiKey = string.Empty;
        private static CookieContainer m_CookieContainer = new CookieContainer();

        static VRCApi()
        {
            RemoteConfig.FetchConfig((config) =>
            {
                m_ApiKey = config.apiKey;
            });
        }

        public static void ClearCookie()
        {
            m_CookieContainer = new CookieContainer();
        }

        public static void LoadCookie()
        {
            Utils.Deserialize(COOKIE_FILE_NAME, ref m_CookieContainer);
        }

        public static void SaveCookie()
        {
            Utils.Serialize(COOKIE_FILE_NAME, m_CookieContainer);
        }

        private static void HandleJson<T>(HttpWebResponse response, Action<T> callback)
        {
            using (var stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    using (var jsonReader = new JsonTextReader(reader))
                    {
                        callback.Invoke(new JsonSerializer().Deserialize<T>(jsonReader));
                    }
                }
            }
        }

        public static async void Request<T>(Action<T> callback, string endpoint, ApiMethod method = ApiMethod.GET, Dictionary<string, object> data = null, Action<HttpWebRequest> setup = null)
        {
            try
            {
                var uri = new UriBuilder(API_URL + endpoint);
                var query = new StringBuilder(uri.Query);
                if (query.Length > 0)
                {
                    query.Remove(0, 1);
                }
                if (method == ApiMethod.GET &&
                    data != null)
                {
                    foreach (var pair in data)
                    {
                        if (query.Length > 0)
                        {
                            query.Append('&');
                        }
                        query.Append(pair.Key);
                        query.Append('=');
                        if (pair.Value != null)
                        {
                            query.Append(Uri.EscapeDataString(pair.Value.ToString()));
                        }
                    }
                }
                if (!string.IsNullOrEmpty(m_ApiKey) &&
                    !"config".Equals(uri.Path))
                {
                    query.Insert(0, "apiKey=" + m_ApiKey + (query.Length > 0 ? "&" : string.Empty));
                }
                uri.Query = query.ToString();
                var request = WebRequest.CreateHttp(uri.Uri);
                request.CookieContainer = m_CookieContainer;
                request.KeepAlive = true;
                request.Method = method.ToString();
                if (setup != null)
                {
                    setup.Invoke(request);
                }
                if (method != ApiMethod.GET &&
                    data != null)
                {
                    request.ContentType = "application/json;charset=utf-8";
                    using (var stream = await request.GetRequestStreamAsync())
                    {
                        using (var writer = new StreamWriter(stream))
                        {
                            using (var jsonWriter = new JsonTextWriter(writer))
                            {
                                new JsonSerializer().Serialize(jsonWriter, data);
                            }
                        }
                    }
                }
                using (var response = await request.GetResponseAsync() as HttpWebResponse)
                {
                    HandleJson(response, callback);
                }
            }
            catch (WebException w)
            {
                try
                {
                    using (var response = w.Response as HttpWebResponse)
                    {
                        if (response.ContentType != null && response.ContentType.IndexOf("json", StringComparison.OrdinalIgnoreCase) != -1)
                        {
                            HandleJson<ApiResponse>(response, MainForm.Instance.OnResponse);
                        }
                        else
                        {
                            MainForm.Instance.ShowMessage(endpoint + ": " + w.Message);
                        }
                    }
                }
                catch (Exception x)
                {
                    MainForm.Instance.ShowMessage(endpoint + ": " + x.Message);
                }
            }
            catch (Exception x)
            {
                MainForm.Instance.ShowMessage(endpoint + ": " + x.Message);
            }
        }

        public static void Login(string username, string password)
        {
            ClearCookie();
            Request<ApiUser>(MainForm.Instance.OnLogin, "auth/user", ApiMethod.GET, null, (request) =>
            {
                request.Headers["Authorization"] = $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"))}";
            });
        }

        public static void ThridPartyLogin(string endpoint, Dictionary<string, object> param)
        {
            ClearCookie();
            Request<ApiUser>(MainForm.Instance.OnLogin, $"auth/{endpoint}", ApiMethod.POST, param);
        }

        public static async void FetchVisits()
        {
            try
            {
                var request = WebRequest.CreateHttp(API_URL + "visits");
                request.KeepAlive = true;
                request.Method = "GET";
                using (var response = await request.GetResponseAsync() as HttpWebResponse)
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            if (int.TryParse(reader.ReadToEnd(), out int n))
                            {
                                MainForm.Instance.OnVisits(n.ToString());
                            }
                        }
                    }
                }
            }
            catch (WebException w)
            {
                MainForm.Instance.ShowMessage(w.Message);
            }
            catch (Exception x)
            {
                MainForm.Instance.ShowMessage(x.Message);
            }
        }
    }

    //
    // RemoteConfig
    //

    public class RemoteConfig
    {
        public string apiKey;

        public static void FetchConfig(Action<RemoteConfig> callback)
        {
            VRCApi.Request(callback, "config");
        }
    }

    //
    // ApiUser
    //

    public class ApiUser
    {
        public enum TrustLevel
        {
            None,
            Visitor,
            NewUser,
            User,
            KnownUser,
            TrustedUser,
            VeteranUser,
            Moderator
        }

        public class FriendStatus
        {
            public bool isFriend;
            public bool incomingRequest;
            public bool outgoingRequest;
        }

        public string id;
        public string displayName;
        public string username;
        public string location;
        public string currentAvatar;
        public string currentAvatarImageUrl;
        public string currentAvatarThumbnailImageUrl;
        public HashSet<string> friends;
        public HashSet<string> tags;
        public bool HasTag(string tag) => tags != null && tags.Contains(tag);
        public string status;
        public string statusDescription;
        public List<string> friendGroupNames;
        public string last_login;

        // VRCEX variable
        public string locationInfo = string.Empty;
        public string pastLocation = string.Empty;
        public string pastLocationInfo = string.Empty;
        public TrustLevel trustLevel = TrustLevel.None;

        public static void Fetch(string id)
        {
            VRCApi.Request<ApiUser>(MainForm.Instance.OnUser, $"users/{id}");
        }

        public static void FetchCurrentUser()
        {
            VRCApi.Request<ApiUser>(MainForm.Instance.OnCurrentUser, "auth/user");
        }

        public static void FetchUsers(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                VRCApi.Request<List<ApiUser>>(MainForm.Instance.OnUsers, "users", ApiMethod.GET, new Dictionary<string, object>
                {
                    ["n"] = 25,
                    ["offset"] = 0,
                    ["search"] = search
                });
            }
        }

        private static void FetchFriends(Action<List<ApiUser>> callback, Dictionary<string, object> param, int count = 100, int offset = 0)
        {
            param["n"] = count;
            param["offset"] = offset;
            VRCApi.Request<List<ApiUser>>((list) =>
            {
                if (list.Count == count)
                {
                    FetchFriends(callback, param, count, offset + count);
                }
                callback.Invoke(list);
            }, "auth/user/friends", ApiMethod.GET, param);
        }

        public static void FetchFriends()
        {
            FetchFriends(MainForm.Instance.OnFriends, new Dictionary<string, object>());
            FetchFriends(MainForm.Instance.OnFriends, new Dictionary<string, object>()
            {
                ["offline"] = "true"
            });
        }

        public static void FetchAllFavoriteFriends()
        {
            VRCApi.Request<List<ApiUser>>(MainForm.Instance.OnUsers, "auth/user/friends/favorite");
        }

        public static void SetStatus(string userId, string status, string statusDescription)
        {
            VRCApi.Request<ApiUser>(MainForm.Instance.OnSetStatus, $"users/{userId}", ApiMethod.PUT, new Dictionary<string, object>()
            {
                ["status"] = status,
                ["statusDescription"] = statusDescription
            });
        }

        // LoadFriendStatus
        public static void CheckFriendStatus(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                VRCApi.Request<FriendStatus>((status) => MainForm.Instance.OnFriendStatus(userId, status), $"user/{userId}/friendStatus");
            }
        }

        // AddFriend
        public static void SendFriendRequest(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                VRCApi.Request<ApiNotification>((response) => MainForm.Instance.OnSendFriendRequest(userId, response), $"user/{userId}/friendRequest", ApiMethod.POST);
            }
        }

        public static void CancelFriendRequest(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                VRCApi.Request<ApiResponse>((response) => MainForm.Instance.OnCancelFriendRequest(userId, response), $"user/{userId}/friendRequest", ApiMethod.DELETE);
            }
        }

        public static void AcceptFriendRequest(string notificationId)
        {
            if (!string.IsNullOrEmpty(notificationId))
            {
                VRCApi.Request<ApiResponse>((response) => MainForm.Instance.OnAcceptFriendRequest(notificationId, response), $"auth/user/notifications/{notificationId}/accept", ApiMethod.PUT);
            }
        }

        public static void DeclineFriendRequest(string notificationId)
        {
            if (!string.IsNullOrEmpty(notificationId))
            {
                VRCApi.Request<ApiNotification>(MainForm.Instance.OnDeclineFriendRequest, $"auth/user/notifications/{notificationId}/hide", ApiMethod.PUT);
            }
        }

        // RemoveFriend
        public static void UnfriendUser(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                VRCApi.Request<ApiResponse>((response) => MainForm.Instance.OnUnfriendUser(userId, response), $"auth/user/friends/{userId}", ApiMethod.DELETE);
            }
        }

        public string GetFriendsGroupDisplayName(int index)
        {
            if (friendGroupNames != null && index < 3 && index < friendGroupNames.Count && !string.IsNullOrEmpty(friendGroupNames[index]))
            {
                return friendGroupNames[index];
            }
            return "Group " + (index + 1);
        }

        public TrustLevel GetTrustLevel()
        {
            if (trustLevel == TrustLevel.None)
            {
                // admin_scripting_access -> Scripting Access
                // admin_avatar_access -> Forced Avatar Access
                // admin_world_access -> Forced World Access
                // admin_lock_tags -> Locked Tags
                // admin_lock_level -> Locked Level
                // system_world_access -> SDK World Access
                // system_avatar_access -> SDK Avatar Access
                // system_feedback_access -> Feedback Access
                // system_legend -> Legendary User
                // system_probable_troll -> Probable Troll
                // system_troll -> Troll
                if (HasTag("admin_moderator"))
                {
                    trustLevel = TrustLevel.Moderator;
                }
                else if (HasTag("system_trust_legend"))
                {
                    trustLevel = TrustLevel.VeteranUser;
                }
                else if (HasTag("system_trust_veteran"))
                {
                    trustLevel = TrustLevel.TrustedUser;
                }
                else if (HasTag("system_trust_trusted"))
                {
                    trustLevel = TrustLevel.KnownUser;
                }
                else if (HasTag("system_trust_known"))
                {
                    trustLevel = TrustLevel.User;
                }
                else if (HasTag("system_trust_basic"))
                {
                    trustLevel = TrustLevel.NewUser;
                }
                else
                {
                    trustLevel = TrustLevel.Visitor;
                }
            }
            return trustLevel;
        }

        /*
            public Color vipNamePlateColor = new Color(0.709803939f, 0.149019614f, 0.149019614f);
            public Color friendNamePlateColor = new Color(1f, 1f, 0f);
            public Color untrustedNamePlateColor = new Color(0.8f, 0.8f, 0.8f);
            public Color basicNamePlateColor = new Color(0.09019608f, 0.470588237f, 1f);
            public Color knownNamePlateColor = new Color(0.168627456f, 0.8117647f, 0.360784322f);
            public Color trustedNamePlateColor = new Color(1f, 0.482352942f, 0.258823544f);
            public Color veteranNamePlateColor = new Color(0.5058824f, 0.2627451f, 0.9019608f);
            public Color legendNamePlateColor = new Color(1f, 1f, 0f);
            public Color trollNamePlateColor = new Color(0.470588237f, 0.184313729f, 0.184313729f);
            public Color mutedNamePlateColor = new Color(0.5f, 0.5f, 0.5f, 0.6f);
        */

        private static readonly Color FriendColor = Color.FromArgb(255, 255, 0);
        private static readonly Color UntrustedColor = Color.FromArgb(128, 128, 128); // (204, 204, 204)
        private static readonly Color BasicColor = Color.FromArgb(23, 120, 255);
        private static readonly Color KnownColor = Color.FromArgb(43, 207, 92);
        private static readonly Color TrustedColor = Color.FromArgb(255, 123, 66);
        private static readonly Color VeteranColor = Color.FromArgb(129, 67, 230);
        private static readonly Color LegendColor = Color.FromArgb(255, 215, 0); // (255, 255, 0)
        private static readonly Color VIPColor = Color.FromArgb(181, 38, 38);
        private static readonly Color TrollColor = Color.FromArgb(120, 47, 47);

        public Color GetColor()
        {
            switch (GetTrustLevel())
            {
                case TrustLevel.NewUser:
                    return BasicColor;
                case TrustLevel.User:
                    return KnownColor;
                case TrustLevel.KnownUser:
                    return TrustedColor;
                case TrustLevel.TrustedUser:
                    return VeteranColor;
                case TrustLevel.VeteranUser:
                    return LegendColor;
                case TrustLevel.Moderator:
                    return VIPColor;
            }
            return UntrustedColor;
        }
    }

    //
    // ApiWorld
    //

    public class ApiWorld
    {
        public string id;
        public string name;
        public string imageUrl;
        public string thumbnailImageUrl;
        public string authorName;
        public string releaseStatus;
        public int capacity;
        public int occupants;
        public string authorId;
        public string assetUrl;
        public string description;
        public string unityPackageUrl;
        public List<List<string>> instances;

        public static void Fetch(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                VRCApi.Request<ApiWorld>(MainForm.Instance.OnWorld, $"worlds/{id}");
            }
        }

        public static void FetchList(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                VRCApi.Request<List<ApiWorld>>(MainForm.Instance.OnWorlds, "worlds", ApiMethod.GET, new Dictionary<string, object>
                {
                    ["n"] = 100,
                    ["offset"] = 0,
                    ["sort"] = "popularity",
                    ["order"] = "descending",
                    ["search"] = search,
                    ["releaseStatus"] = "public"
                });
            }
        }

        public static void FetchMyList()
        {
            VRCApi.Request<List<ApiWorld>>(MainForm.Instance.OnWorlds, "worlds", ApiMethod.GET, new Dictionary<string, object>
            {
                ["n"] = 100,
                ["offset"] = 0,
                ["user"] = "me",
                ["sort"] = "updated",
                ["order"] = "descending",
                ["releaseStatus"] = "all"
            });
        }

        public static void FetchListByUser(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                VRCApi.Request<List<ApiWorld>>(MainForm.Instance.OnWorlds, "worlds", ApiMethod.GET, new Dictionary<string, object>
                {
                    ["n"] = 100,
                    ["offset"] = 0,
                    ["userId"] = userId,
                    ["sort"] = "updated",
                    ["order"] = "descending",
                    ["releaseStatus"] = "public"
                });
            }
        }

        public static void FetchRecentList()
        {
            VRCApi.Request<List<ApiWorld>>(MainForm.Instance.OnWorlds, "worlds/recent", ApiMethod.GET, new Dictionary<string, object>
            {
                ["n"] = 100,
                ["offset"] = 0,
                ["releaseStatus"] = "all"
            });
        }

        public static void FetchFavoriteList()
        {
            VRCApi.Request<List<ApiWorld>>(MainForm.Instance.OnWorlds, "worlds/favorites");
        }
    }

    public class ApiWorldInstance
    {
        public string id;
        public List<ApiUser> users;

        public static void Fetch(string worldId, string instanceId)
        {
            if (!string.IsNullOrEmpty(worldId) &&
                !string.IsNullOrEmpty(instanceId))
            {
                VRCApi.Request<ApiWorldInstance>(MainForm.Instance.OnWorldInstance, $"worlds/{worldId}/{instanceId}");
            }
        }
    }

    //
    // ApiAvatar
    //

    public class ApiAvatar
    {
        public string id;
        public string name;
        public string imageUrl;
        public string authorName;
        public string authorId;
        public string assetUrl;
        public string description;
        public string unityPackageUrl;
        public string thumbnailImageUrl;
        public string releaseStatus;

        public static void Fetch(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                VRCApi.Request<ApiAvatar>(MainForm.Instance.OnAvatar, $"avatars/{id}");
            }
        }

        private static void FetchList(Action<List<ApiAvatar>> callback, Dictionary<string, object> param, int count = 100, int offset = 0)
        {
            param["n"] = count;
            param["offset"] = offset;
            VRCApi.Request<List<ApiAvatar>>((list) =>
            {
                if (list.Count == count && offset + count < 500)
                {
                    FetchList(callback, param, count, offset + count);
                }
                callback.Invoke(list);
            }, "avatars", ApiMethod.GET, param);
        }

        public static void FetchMyList()
        {
            FetchList(MainForm.Instance.OnAvatars, new Dictionary<string, object>
            {
                ["user"] = "me",
                ["sort"] = "updated",
                ["order"] = "descending",
                ["releaseStatus"] = "all"
            });
        }

        public static void FetchListByUser(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                FetchList(MainForm.Instance.OnAvatars, new Dictionary<string, object>
                {
                    ["userId"] = userId,
                    ["sort"] = "updated",
                    ["order"] = "descending",
                    ["releaseStatus"] = "public"
                });
            }
        }

        public static void FetchFavoriteList()
        {
            VRCApi.Request<List<ApiAvatar>>(MainForm.Instance.OnAvatars, "avatars/favorites");
        }

        public static void AssignToThisUser(string avatarId)
        {
            if (!string.IsNullOrEmpty(avatarId))
            {
                VRCApi.Request<ApiUser>(MainForm.Instance.OnCurrentUser, $"avatars/{avatarId}/select", ApiMethod.PUT);
            }
        }
    }

    //
    // ApiFavorite
    //

    public class ApiFavorite
    {
        public enum FavoriteType
        {
            Friend,
            World,
            Avatar
        }

        public string id;
        public string type;
        public string favoriteId;
        public HashSet<string> tags;

        public static void FetchList(FavoriteType type, string tags = null)
        {
            var param = new Dictionary<string, object>
            {
                ["n"] = 100,
                ["type"] = type.ToString().ToLower()
            };
            if (!string.IsNullOrEmpty(tags))
            {
                param["tags"] = tags;
            }
            VRCApi.Request<List<ApiFavorite>>((list) => MainForm.Instance.OnFavorites(type, list), "favorites", ApiMethod.GET, param);
        }

        public static void AddFavorite(string objectId, FavoriteType type, string tags = null)
        {
            if (!string.IsNullOrEmpty(objectId))
            {
                var param = new Dictionary<string, object>()
                {
                    ["type"] = type.ToString().ToLower(),
                    ["favoriteId"] = objectId
                };
                if (!string.IsNullOrEmpty(tags))
                {
                    param["tags"] = tags;
                }
                VRCApi.Request<ApiFavorite>(MainForm.Instance.OnAddFavorite, "favorites", ApiMethod.POST, param);
            }
        }

        public static void RemoveFavorite(string objectId)
        {
            if (!string.IsNullOrEmpty(objectId))
            {
                VRCApi.Request<ApiResponse>(MainForm.Instance.OnRemoveFavorite, $"favorites/{objectId}", ApiMethod.DELETE);
            }
        }
    }

    //
    // ApiPlayerModeration
    //

    public class ApiPlayerModeration
    {
        public enum ModerationType
        {
            None,
            Block,
            Mute,
            Unmute,
            HideAvatar,
            ShowAvatar
        }

        public string id;
        public string type;
        public string targetUserId;
        public string targetDisplayName;
        public string sourceUserId;
        public string sourceDisplayName;
        public string created;

        public static void FetchAllMine()
        {
            // VRCApi.Request<List<ApiPlayerModeration>>(MainForm.Instance.OnPlayerModerations, "auth/user/playermoderations");
            VRCApi.Request<List<ApiPlayerModeration>>(MainForm.Instance.OnPlayerModerations, "auth/user/playermoderations?type=block");
            VRCApi.Request<List<ApiPlayerModeration>>(MainForm.Instance.OnPlayerModerations, "auth/user/playermoderations?type=mute");
            VRCApi.Request<List<ApiPlayerModeration>>(MainForm.Instance.OnPlayerModerations, "auth/user/playermoderations?type=hideAvatar");
        }

        public static void FetchAllAgainstMe()
        {
            VRCApi.Request<List<ApiPlayerModeration>>(MainForm.Instance.OnPlayerModerationsAgainstMe, "auth/user/playermoderated");
        }

        public static void SendModeration(string targetUserId, ModerationType type)
        {
            if (!string.IsNullOrEmpty(targetUserId))
            {
                VRCApi.Request<ApiPlayerModeration>(MainForm.Instance.OnSendModeration, "auth/user/playermoderations", ApiMethod.POST, new Dictionary<string, object>
                {
                    ["moderated"] = targetUserId,
                    ["type"] = ModerationTypeToAPIString(type)
                });
            }
        }

        public static void DeleteModeration(string targetUserId, ModerationType type)
        {
            if (!string.IsNullOrEmpty(targetUserId))
            {
                VRCApi.Request<ApiResponse>(MainForm.Instance.OnDeleteModeration, "auth/user/unplayermoderate", ApiMethod.PUT, new Dictionary<string, object>
                {
                    ["moderated"] = targetUserId,
                    ["type"] = ModerationTypeToAPIString(type)
                });
            }
        }

        public static string ModerationTypeToAPIString(ModerationType type)
        {
            switch (type)
            {
                case ModerationType.ShowAvatar:
                    return "showAvatar";
                case ModerationType.HideAvatar:
                    return "hideAvatar";
                default:
                    return type.ToString().ToLower();
            }
        }
    }

    //
    // ApiNotification
    //

    public class ApiNotification
    {
        public enum NotificationType
        {
            All,
            Message,
            FriendRequest,
            Invite,
            RequestInvite,
            VoteToKick,
            Halp,
            Hidden
        }

        public string id;
        public string senderUserId;
        public string senderUsername;
        public string type;
        public string message;
        public string created_at;
        public string details;

        private static void FetchAll(Action<List<ApiNotification>> callback, Dictionary<string, object> param, int count = 100, int offset = 0)
        {
            param["n"] = count;
            param["offset"] = offset;
            VRCApi.Request<List<ApiNotification>>((list) =>
            {
                if (list.Count == count)
                {
                    FetchAll(callback, param, count, offset + count);
                }
                callback.Invoke(list);
            }, "auth/user/notifications", ApiMethod.GET, param);
        }

        public static void FetchAll(NotificationType type, string afterString)
        {
            var param = new Dictionary<string, object>();
            if (type != NotificationType.All)
            {
                param["type"] = (type == NotificationType.FriendRequest) ? "friendRequest" : type.ToString().ToLower();
            }
            if (!string.IsNullOrEmpty(afterString))
            {
                param["after"] = afterString;
            }
            FetchAll(MainForm.Instance.OnNotifications, param);
        }

        /*public static void MarkNotificationAsSeen(string notificationId)
        {
            if (!string.IsNullOrEmpty(notificationId))
            {
                Http.Request<ApiNotification>(MainForm.Instance.OnMarkNotificationAsSeen, $"auth/user/notifications/{notificationId}/see", RequestMethod.Put);
            }
        }*/
    }

    //
    // ApiFile
    //

    public class ApiFile
    {
        public class Version
        {
            public class FileDescriptor
            {
                public string url;
                public int sizeInBytes;
            }

            public string created_at;
            public FileDescriptor file;
        }

        public string id;
        public List<Version> versions;

        public static void Fetch(string id, object arg)
        {
            if (!string.IsNullOrEmpty(id))
            {
                VRCApi.Request<ApiFile>((file) => MainForm.Instance.OnFile(arg, file), $"file/{id}");
            }
        }

        public static void ParseAndFetch(string url, object tag)
        {
            if (!string.IsNullOrEmpty(url))
            {
                var begin = url.IndexOf("/api/1/file/");
                if (begin >= 0)
                {
                    var end = url.IndexOf('/', begin += 12);
                    if (end < 0)
                    {
                        end = url.Length;
                    }
                    if (begin < end)
                    {
                        Fetch(url.Substring(begin, end - begin), tag);
                    }
                }
            }
        }
    }

    //
    // LocationInfo
    //

    public class LocationInfo
    {
        public string WorldId = string.Empty;
        public string InstanceId = string.Empty;
        public string InstanceInfo = string.Empty;

        public static LocationInfo Parse(string idWithTags, bool strict = true)
        {
            // offline
            // private
            // local:0000000000
            // Public       wrld_785bee79-b83b-449c-a3d9-f1c5a29bcd3d:12502
            // Friends+     wrld_785bee79-b83b-449c-a3d9-f1c5a29bcd3d:12502~hidden(usr_4f76a584-9d4b-46f6-8209-8305eb683661)~nonce(79985ba6-8804-49dd-8c8a-c86fe817caca)
            // Friends      wrld_785bee79-b83b-449c-a3d9-f1c5a29bcd3d:12502~friends(usr_4f76a584-9d4b-46f6-8209-8305eb683661)~nonce(13374166-629e-4ac5-afe9-29637719d78c)
            // Invite+      wrld_785bee79-b83b-449c-a3d9-f1c5a29bcd3d:12502~private(usr_4f76a584-9d4b-46f6-8209-8305eb683661)~nonce(6d9b02ca-f32c-4360-b8ac-9996bf12fd74)~canRequestInvite
            // Invite       wrld_785bee79-b83b-449c-a3d9-f1c5a29bcd3d:12502~private(usr_4f76a584-9d4b-46f6-8209-8305eb683661)~nonce(5db0f688-4211-428b-83c5-91533e0a5d5d)
            // wrld_가 아니라 wld_인 것들도 있고 예전 맵들의 경우 아예 o_나 b_인것들도 있음; 그냥 uuid형태인 것들도 있고 개판임
            var tags = idWithTags.Split('~');
            var a = tags[0].Split(new char[] { ':' }, 2);
            if (!string.IsNullOrEmpty(a[0]))
            {
                if (a.Length == 2)
                {
                    if (!string.IsNullOrEmpty(a[1]) &&
                        !"local".Equals(a[0]))
                    {
                        var L = new LocationInfo
                        {
                            WorldId = a[0]
                        };
                        var type = "public";
                        if (tags.Length > 1)
                        {
                            var tag = "~" + string.Join("~", tags, 1, tags.Length - 1);
                            if (tag.Contains("~private("))
                            {
                                if (tag.Contains("~canRequestInvite"))
                                {
                                    type = "invite+"; // Invite Plus
                                }
                                else
                                {
                                    type = "invite"; // Invite Only
                                }
                            }
                            else if (tag.Contains("~friends("))
                            {
                                type = "friends"; // Friends Only
                            }
                            else if (tag.Contains("~hidden("))
                            {
                                type = "friends+"; // Friends of Guests
                            }
                            L.InstanceId = a[1] + tag;
                        }
                        else
                        {
                            L.InstanceId = a[1];
                        }
                        L.InstanceInfo = $"#{a[1]} {type}";
                        return L;
                    }
                }
                else if (!strict && !("offline".Equals(a[0]) || "private".Equals(a[0])))
                {
                    return new LocationInfo()
                    {
                        WorldId = a[0]
                    };
                }
            }
            return null;
        }
    }
}