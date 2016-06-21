using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class DataController : MonoBehaviour
{
    private string secretKey = "mySecretKey";
    const string URL = "http://www.pontura.com/matematicas/";
    private string getUserIdByEmail_URL = URL + "getUserIdByEmail.php?";
    private string createUser_URL = URL + "createUser.php?";
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

                //SetUserData(username, userID, email);
                Data.Instance.userData.OnRegistration(username, email, password, userID, false);
            }
            catch
            {
                Debug.Log("New user!");
                CreateUser(_username, _email, UnityEngine.Random.Range(10000, 99999).ToString());
            }
        }
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

