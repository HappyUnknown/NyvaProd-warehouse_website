using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NyvaProdBC
{
    public partial class LoginPage : System.Web.UI.Page
    {
        public static bool HideCookieRequest { get; set; }
        public static bool CookieAllowed { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookies = Request.Cookies[GlobalValues.COOKIE_DEPARTMENT];
            if (cookies != null)
            {
                string cookieMsgHiddenValue = cookies.Values[GlobalValues.COOKIES_HIDDEN_NAME];
                if (cookieMsgHiddenValue != null)
                {
                    if (cookieMsgHiddenValue == GlobalValues.CookieMessageState.Requested.ToString())
                    {
                        HideCookieRequest = true;
                    }
                    else HideCookieRequest = false;
                }
                else HideCookieRequest = false;

                string cookieAllowed = cookies.Values[GlobalValues.ALLOW_COOKIES_NAME];
                if (cookieAllowed != null)
                {
                    if (cookieAllowed == GlobalValues.CookieMode.Allowed.ToString())
                    {
                        CookieAllowed = true;
                    }
                    else CookieAllowed = false;
                }
                else CookieAllowed = false;
                chkRememberMe.Visible = CookieAllowed;

                if (cookies.Values[GlobalValues.COOKIE_NAMES[0]] != null && cookies.Values[GlobalValues.COOKIE_NAMES[1]] != null)
                {
                    tbEmail.Text = cookies.Values[GlobalValues.COOKIE_NAMES[0]];
                    tbPassword.Text = cookies.Values[GlobalValues.COOKIE_NAMES[1]];
                }
            }
            else { Response.Write("<script>alert('NO COOKIES FOUND')</script>"); }
        }
        Entity.NyvaUser GetUserInput(bool encode = true)
        {
            string password = encode ? MD5Hasher.Encrypt(tbPassword.Text) : tbPassword.Text;
            return new Entity.NyvaUser("NO_FIRST_NAME_INPUT", "NO_LAST_NAME_INPUT", "NO_FATHER_NAME_INPUT", tbEmail.Text, "NO_PHONE_INPUT", password, GlobalValues.USER_ROLE, GlobalValues.USER_BANNED);
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            List<Entity.NyvaUser> users = new Entity.Contexts.NyvaUserContext().Users.ToList();
            for (int i = 0; i < users.Count; i++)
            {
                Entity.NyvaUser userInput = GetUserInput();
                if (users[i].Email == GetUserInput().Email && users[i].Password == GetUserInput().Password)
                {
                    Application["user_data"] = users[i];
                    if (chkRememberMe.Checked)
                    {
                        HttpCookie cookies = new HttpCookie(GlobalValues.COOKIE_DEPARTMENT);
                        cookies[GlobalValues.COOKIE_NAMES[0]] = tbEmail.Text;
                        cookies[GlobalValues.COOKIE_NAMES[1]] = tbPassword.Text;
                        cookies.Expires = DateTime.Now.AddSeconds(15);
                        Response.Cookies.Add(cookies);
                    }
                    Response.Write("<script>alert('Користувач увійшов як " + users[i].Email + ": " + users[i].Password.ToString() + "==" + userInput.Password + "');</script>");
                    Response.Redirect("/Default");
                }
                else
                {
                    Response.Write("<script>alert('" + users[i].Email + "==" + userInput.Email + " | " + users[i].Password.ToString() + "==" + userInput.Password + "');</script>");
                }
            }
            Response.Write("<script>alert('Користувач з такими даними не існує.');</script>");
        }

        protected void btnRestore_Click(object sender, EventArgs e)
        {
            Response.Redirect("/RequestRestorePassword");
        }

        protected void chkSeePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == true)
            {
                tbPassword.TextMode = TextBoxMode.SingleLine;
            }
            else tbPassword.TextMode = TextBoxMode.Password;
        }

        protected void btnGetPassword_Click(object sender, EventArgs e)
        {
            //Master.UPMaster.Update();//Can be used to set textbox value inside of update panel: https://stackoverflow.com/questions/28837838/how-to-update-textbox-onchange-without-postback
            //tbShadow.Text = tbPassword.Text;
        }

        protected void btnDisallowCookies_Click(object sender, EventArgs e)
        {
            chkRememberMe.DataBind();
            chkRememberMe.Visible = CookieAllowed;
            HttpCookie cookies = new HttpCookie(GlobalValues.COOKIE_DEPARTMENT);
            string cookiesHiddenName = GlobalValues.COOKIES_HIDDEN_NAME;
            string newStateValue = GlobalValues.CookieMessageState.Requested.ToString();
            string allowCookies = GlobalValues.ALLOW_COOKIES_NAME;
            string newAllowCookieValue = GlobalValues.CookieMode.Disallowed.ToString();
            cookies.Values[cookiesHiddenName] = newStateValue;
            cookies.Values[allowCookies] = newAllowCookieValue;
            cookies.Expires = DateTime.Now.AddSeconds(15);
            Response.Cookies.Add(cookies);
            HideCookieRequest = true;
            Master.UPMaster.Update();
        }

        protected void btnAllowCookies_Click(object sender, EventArgs e)
        {
            chkRememberMe.DataBind();
            chkRememberMe.Visible = CookieAllowed;
            HttpCookie cookies = new HttpCookie(GlobalValues.COOKIE_DEPARTMENT);
            string cookiesHiddenName = GlobalValues.COOKIES_HIDDEN_NAME;
            string newStateValue = GlobalValues.CookieMessageState.Requested.ToString();
            string allowCookies = GlobalValues.ALLOW_COOKIES_NAME;
            string newAllowCookieValue = GlobalValues.CookieMode.Allowed.ToString();
            cookies.Values[cookiesHiddenName] = newStateValue;
            cookies.Values[allowCookies] = newAllowCookieValue;
            cookies.Expires = DateTime.Now.AddSeconds(15);
            Response.Cookies.Add(cookies);
            HideCookieRequest = true;
            Master.UPMaster.Update();
        }
    }
}