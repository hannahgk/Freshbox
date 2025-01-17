﻿using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FreshBox.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Logged : ContentPage
    {
        public Logged()
        {
            InitializeComponent();

            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadToken(App.user.IdToken) as JwtSecurityToken;
            lstToken.ItemsSource = tokenS.Claims.ToList();
            string userSub = tokenS.Claims.First(claim => claim.Type == "sub").Value;

            lblTitle.Text = "WELCOME " + tokenS.Claims.First(claim => claim.Type == "cognito:username").Value.ToUpper();
            //lblUserName.Text = tokenS.Claims.First(claim => claim.Type == "cognito:username").Value;
            //lblEmail.Text = tokenS.Claims.First(claim => claim.Type == "email").Value;

            // Update User Attributes

            //App.provider.UpdateUserAttributesAsync(new Amazon.CognitoIdentityProvider.Model.UpdateUserAttributesRequest
            //{
            //    UserAttributes = 
            //})
        }
    }
}

