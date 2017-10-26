using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class DataController : MonoBehaviour
{
    private string secretKey = "mySecretKey";
    const string URL = "http://juegos.buber.edu.ar/chacmool/";
    private string getUserIdByEmail_URL = URL + "getUserIdByEmail.php?";
    private string createUser_URL = URL + "createUser.php?";
    private string addNewData_URL = URL + "addNewData.php?";
    private string getRanking_URL = URL + "getRanking.php?";
    private string saveRanking_URL = URL + "saveRanking.php?";
    private string setUserFilter_URL = URL + "setUserFilter.php?";
    private string getUsersByFilter_URL = URL + "getUsersByFilter.php?";
    private string saveBlock_URL = URL + "saveBlock.php?";
    private string getEjercicios_URL = URL + "getEjercicios.php?";

    void Start()
    {
        SocialEvents.OnLogin += OnLogin;
        SocialEvents.OnGetRanking += OnGetRanking;
        SocialEvents.OnSaveAchievements += OnSaveAchievements;
        SocialEvents.OnSetFiltered += OnSetFiltered;
        SocialEvents.OnGetAlumnos += OnGetAlumnos;
        Events.OnSaveBlockToDB += OnSaveBlockToDB;
        SocialEvents.OnGetEjercicios += OnGetEjercicios;
        //SocialEvents.OnCompetitionHiscore += OnCompetitionHiscore;
        //SocialEvents.OnGetHiscores += OnGetHiscores;
    }
    void OnLogin(string username, string email)
    {
        StartCoroutine(CheckIfUserExistsOnLocalDB(username, email));
        // CreateUser(username, email, "AAA");
    }
    IEnumerator CheckIfUserExistsOnLocalDB(string _username, string _email)
    {
        if (_email == "")
            yield break;

        string post_url = getUserIdByEmail_URL + "email=" + _email;
        WWW receivedData = new WWW(post_url);
        yield return receivedData;
        if (receivedData.error != null)
            print("There was an error in CheckIfUserExistsOnLocalDB: " + receivedData.error);
        else
        {
            try
            {
                print("Usuario ya existente: " + receivedData.text);

                string[] userData = Regex.Split(receivedData.text, ":");
                int userID = System.Int32.Parse(userData[1]);
                string username = userData[2];
                string password = userData[3];
                string email = userData[4];
                int achievements = System.Int32.Parse(userData[5]);

                int distance = System.Int32.Parse(userData[5]);
                int island_active = System.Int32.Parse(userData[6]);
                int mission_active = System.Int32.Parse(userData[7]);
                int sex = System.Int32.Parse(userData[8]);
                int clothes = System.Int32.Parse(userData[9]);
                int legs = System.Int32.Parse(userData[10]);
                int shoes = System.Int32.Parse(userData[11]);
                int skin = System.Int32.Parse(userData[12]);
                int hairs    = System.Int32.Parse(userData[13]);

                int progressIsland_1 = System.Int32.Parse(userData[14]);
                int progressIsland_2 = System.Int32.Parse(userData[15]);
                int progressIsland_3 = System.Int32.Parse(userData[16]);
                int progressIsland_4 = System.Int32.Parse(userData[17]);
                int progressIsland_5 = System.Int32.Parse(userData[18]);
                int progressIsland_6 = System.Int32.Parse(userData[19]);
                int progressIsland_7 = System.Int32.Parse(userData[20]);
                int progressIsland_8 = System.Int32.Parse(userData[21]);
                int progressIsland_9 = System.Int32.Parse(userData[22]);
                int progressIsland_10 = System.Int32.Parse(userData[23]);
                int progressIsland_11 = System.Int32.Parse(userData[24]);
                int progressIsland_12 = System.Int32.Parse(userData[25]);
                int progressIsland_13 = System.Int32.Parse(userData[26]);
                int progressIsland_14 = System.Int32.Parse(userData[27]);
                int progressIsland_15 = System.Int32.Parse(userData[28]);
                int progressIsland_16 = System.Int32.Parse(userData[29]);
                int progressIsland_17 = System.Int32.Parse(userData[30]);
                int progressIsland_18 = System.Int32.Parse(userData[31]);
                int progressIsland_19 = System.Int32.Parse(userData[32]);
                //SetUserData(username, userID, email)

                if (distance == 0)
                {
                    Debug.Log("Ya existias pero sos nuevo en esta compu");
                    SaveNewData(email);
                } else
                {
                    Debug.Log("Ya jugo antes");
                    PlayerPrefs.SetInt("progressIsland_1", progressIsland_1);
                    PlayerPrefs.SetInt("progressIsland_2", progressIsland_2);
                    PlayerPrefs.SetInt("progressIsland_3", progressIsland_3);
                    PlayerPrefs.SetInt("progressIsland_4", progressIsland_4);
                    PlayerPrefs.SetInt("progressIsland_5", progressIsland_5);
                    PlayerPrefs.SetInt("progressIsland_6", progressIsland_6);
                    PlayerPrefs.SetInt("progressIsland_7", progressIsland_7);
                    PlayerPrefs.SetInt("progressIsland_8", progressIsland_8);
                    PlayerPrefs.SetInt("progressIsland_9", progressIsland_9);
                    PlayerPrefs.SetInt("progressIsland_10", progressIsland_10);
                    PlayerPrefs.SetInt("progressIsland_11", progressIsland_11);
                    PlayerPrefs.SetInt("progressIsland_12", progressIsland_12);
                    PlayerPrefs.SetInt("progressIsland_13", progressIsland_13);
                    PlayerPrefs.SetInt("progressIsland_14", progressIsland_14);
                    PlayerPrefs.SetInt("progressIsland_15", progressIsland_15);
                    PlayerPrefs.SetInt("progressIsland_16", progressIsland_16);
                    PlayerPrefs.SetInt("progressIsland_17", progressIsland_17);
                    PlayerPrefs.SetInt("progressIsland_18", progressIsland_18);
                    PlayerPrefs.SetInt("progressIsland_19", progressIsland_19);

                    PlayerPrefs.SetInt("distance", distance);
                    PlayerPrefs.SetInt("island_active", island_active);
                    PlayerPrefs.SetInt("mission_active", mission_active);
                    PlayerPrefs.SetInt("sex", sex);
                    PlayerPrefs.SetInt("clothes", clothes);
                    PlayerPrefs.SetInt("legs", legs);
                    PlayerPrefs.SetInt("shoes", shoes);
                    PlayerPrefs.SetInt("skin", skin);
                    PlayerPrefs.SetInt("hairs", hairs);
                }
                Data.Instance.userData.OnRegistration(username, email, password, userID, false);
            }
            catch
            {
                Debug.Log("New user!");
                CreateUser(_username, _email, UnityEngine.Random.Range(10000, 99999).ToString());
            }
        }
    }
    void SaveNewData(string email)
    {
        int progressIsland_1 = PlayerPrefs.GetInt("progressIsland_1", 0);
        int progressIsland_2 = PlayerPrefs.GetInt("progressIsland_2", 0);
        int progressIsland_3 = PlayerPrefs.GetInt("progressIsland_3", 0);
        int progressIsland_4 = PlayerPrefs.GetInt("progressIsland_4", 0);
        int progressIsland_5 = PlayerPrefs.GetInt("progressIsland_5", 0);
        int progressIsland_6 = PlayerPrefs.GetInt("progressIsland_6", 0);
        int progressIsland_7 = PlayerPrefs.GetInt("progressIsland_7", 0);
        int progressIsland_8 = PlayerPrefs.GetInt("progressIsland_8", 0);
        int progressIsland_9 = PlayerPrefs.GetInt("progressIsland_9", 0);
        int progressIsland_10 = PlayerPrefs.GetInt("progressIsland_10", 0);
        int progressIsland_11 = PlayerPrefs.GetInt("progressIsland_11", 0);
        int progressIsland_12 = PlayerPrefs.GetInt("progressIsland_12", 0);
        int progressIsland_13 = PlayerPrefs.GetInt("progressIsland_13", 0);
        int progressIsland_14 = PlayerPrefs.GetInt("progressIsland_14", 0);
        int progressIsland_15 = PlayerPrefs.GetInt("progressIsland_15", 0);
        int progressIsland_16 = PlayerPrefs.GetInt("progressIsland_16", 0);
        int progressIsland_17 = PlayerPrefs.GetInt("progressIsland_17", 0);
        int progressIsland_18 = PlayerPrefs.GetInt("progressIsland_18", 0);
        int progressIsland_19 = PlayerPrefs.GetInt("progressIsland_19", 0);

        int distance = PlayerPrefs.GetInt("distance", 0);
        int island_active = PlayerPrefs.GetInt("island_active", 0);
        int mission_active = PlayerPrefs.GetInt("mission_active", 0);
        int sex = PlayerPrefs.GetInt("sex", 0);
        int clothes = PlayerPrefs.GetInt("clothes", 0);
        int legs = PlayerPrefs.GetInt("legs", 0);
        int shoes = PlayerPrefs.GetInt("shoes", 0);
        int skin = PlayerPrefs.GetInt("skin", 0);
        int hairs = PlayerPrefs.GetInt("hairs", 0);
        
        string hash = Md5Test.Md5Sum(email + secretKey);
        string post_url = addNewData_URL + "email=" + email +
            "&p1=" + progressIsland_1 +
            "&p2=" + progressIsland_2 +
            "&p3=" + progressIsland_3 +
            "&p4=" + progressIsland_4 +
            "&p5=" + progressIsland_5 +
            "&p6=" + progressIsland_6 +
            "&p7=" + progressIsland_7 +
            "&p8=" + progressIsland_8 +
            "&p9=" + progressIsland_9 +
            "&p10=" + progressIsland_10 +
            "&p11=" + progressIsland_11 +
            "&p12=" + progressIsland_12 +
            "&p13=" + progressIsland_13 +
            "&p14=" + progressIsland_14 +
            "&p15=" + progressIsland_15 +
            "&p16=" + progressIsland_16 +
            "&p17=" + progressIsland_17 +
            "&p18=" + progressIsland_18 +
            "&p19=" + progressIsland_19 +

            "&di=" + distance +
            "&is=" + island_active +
            "&m1=" + mission_active +
            "&se=" + sex +
            "&c1=" + clothes +
            "&le=" + legs +
            "&sh=" + shoes +
            "&sk=" + skin +
            "&ha=" + hairs;

        print("SaveNewData : " + post_url);
        WWW hs_post = new WWW(post_url);
    }
    public void CreateUser(string username, string email, string password)
    {
        StartCoroutine(CreateUserRoutine(username, email, password));
    }
    IEnumerator CreateUserRoutine(string username, string email, string password)
    {
        username = username.Replace(" ", "_");
        string hash = Md5Test.Md5Sum(username + email + password + secretKey);
        string post_url = createUser_URL + "username=" + username + "&email=" + email + "&password=" + password + "&hash=" + hash;
        print("CreateUser : " + post_url);
        WWW hs_post = new WWW(post_url);
        yield return hs_post;
        if (hs_post.error != null)
            print("No pudo crear el nuevo user: " + hs_post.error);
        else
        {
            print("user agregado: " + hs_post.text);
            int userId = int.Parse(hs_post.text);
            Data.Instance.userData.OnRegistration(username, email, password, userId, true);
        }
    }

    /////////////////////////////////////
    private System.Action<string> RankingListener;
    public void OnGetRanking(System.Action<string> RankingListener)
    {
        this.RankingListener = RankingListener;
        StartCoroutine(GetRankingRoutine());
    }
    IEnumerator GetRankingRoutine()
    {
        string post_url = getRanking_URL;
        print("GetRankingRoutine : " + post_url);
        WWW receivedData = new WWW(post_url);
        yield return receivedData;
        if (receivedData.error != null)
            print("There was an error in getting hiscores: " + receivedData.error);
        else
        {
            RankingListener(receivedData.text);
        }
    }
    /////////////////////////////////////

    void OnSaveAchievements(int totalToSave)
    {
        StartCoroutine(OnSaveAchievementsRoutine(totalToSave));
    }
    IEnumerator OnSaveAchievementsRoutine(int total)
    {
        string hash = Md5Test.Md5Sum(Data.Instance.userData.userID.ToString() + total.ToString() + secretKey);
        string post_url = saveRanking_URL + "userID=" + Data.Instance.userData.userID + "&total=" + total + "&hash=" + hash;
        print("OnSaveAchievementsRoutine : " + post_url);
        WWW hs_post = new WWW(post_url);
        yield return hs_post;
        if (hs_post.error != null)
            print("No pudo updatear achievements: " + hs_post.error);
        else
        {
            print("achievements updateado: " + hs_post.text);
          //  int userId = int.Parse(hs_post.text);
        }
    }

    private System.Action OnSetFilteredListener;
    void OnSetFiltered(int userID, int filtered, System.Action OnSetFilteredListener)
    {
        this.OnSetFilteredListener = OnSetFilteredListener;
        StartCoroutine(OnSetFilteredRoutine(userID, filtered));
    }
    IEnumerator OnSetFilteredRoutine(int userID, int filtered)
    {
        string hash = Md5Test.Md5Sum(userID.ToString() + filtered.ToString() + secretKey);
        string post_url = setUserFilter_URL + "userID=" + userID + "&filtered=" + filtered + "&hash=" + hash;
        print("setUserFilter_URL : " + post_url);
        WWW hs_post = new WWW(post_url);
        yield return hs_post;
        if (hs_post.error != null)
            print("No pudo updatear filter: " + hs_post.error);
        else
        {
            print("filter updateado: " + hs_post.text);
            OnSetFilteredListener();
        }
    }

    /////////////////////////////////////
    private System.Action<string> OnGetAlumnosListener;
    public void OnGetAlumnos(int filtered, System.Action<string> OnGetAlumnosListener)
    {
        this.OnGetAlumnosListener = OnGetAlumnosListener;
        StartCoroutine(OnGetAlumnosRoutine(filtered));
    }
    IEnumerator OnGetAlumnosRoutine(int filtered)
    {
        string post_url = getUsersByFilter_URL + "filtered=" + filtered.ToString();
        print("getUsersByFilter_URL : " + post_url);
        WWW receivedData = new WWW(post_url);
        yield return receivedData;
        if (receivedData.error != null)
            print("There was an error in getting hiscores: " + receivedData.error);
        else
        {
            OnGetAlumnosListener(receivedData.text);
        }
    }
    /////////////////////////////////////




    public void OnSaveBlockToDB(string title, string content)
    {
        StartCoroutine(OnSaveBlockToDBRoutine(Data.Instance.userData.userID, title, content));
    }
    IEnumerator OnSaveBlockToDBRoutine(int userID, string title, string content)
    {
        string hash = Md5Test.Md5Sum(userID.ToString() + title + content + secretKey);
        string post_url = saveBlock_URL + "userID=" + userID + "&title=" + WWW.EscapeURL(title) + "&content=" + WWW.EscapeURL(content) + "&hash=" + hash;
        print("OnSaveBlockToDBRoutine : " + post_url);
        WWW hs_post = new WWW(post_url);
        yield return hs_post;
        if (hs_post.error != null)
            print("No pudo crear el nuevo user: " + hs_post.error);
        else
        {
            print("OnSaveBlockToDBRoutine agregado: " + hs_post.text);
        }
    }



    /////////////////////////////////////
    private System.Action<string> OnGetEjerciciosListener;
    public void OnGetEjercicios(int userID, System.Action<string> OnGetAlumnosListener)
    {
        this.OnGetEjerciciosListener = OnGetAlumnosListener;
        StartCoroutine(OnGetEjerciciosRoutine(userID));
    }
    IEnumerator OnGetEjerciciosRoutine(int userID)
    {
        string post_url = getEjercicios_URL + "userID=" + userID.ToString();
        print("OnGetEjerciciosRoutine : " + post_url);
        WWW receivedData = new WWW(post_url);
        yield return receivedData;
        if (receivedData.error != null)
            print("There was an error in getting hiscores: " + receivedData.error);
        else
        {
            OnGetEjerciciosListener(receivedData.text);
        }
    }
    /////////////////////////////////////
    


}

