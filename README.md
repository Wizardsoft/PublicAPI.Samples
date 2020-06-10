# PublicAPI.Samples

Welcome to Wizardsoft API integration platform using OAuth 2.0 Authorization Code Workflow to your application to authorize user.

You can add your `ClientID` and `ClientSecret` fields in the web.config/appsettings.json/constants etc.

## Setup Instruction

At first you need to register your app from https://api.wizardsoft.com/registerapp. Here you need to provide at least one redirect url which will responsible for OAuth Redirect Callback. After successful registration you will get ClientId and Client Secret.

## Authorization
First you need to retrive an authorization code for further process. When you will send request to https://api.wizardsoft.com/core
with the parameters using FormUrlEncodded or query string.

1. client_id - The API key provided to you by `WizardSoft`.
2. redirect_uri - The URL the user should be redirected back to after they've confirmed they want to give you access to the API.
3. scope - The scopes you wish to request separated by spaces. It's all scopes that will work for your application.
4. response_type - This should always be the value 'code'.
5. state - Pass a unique value in this field and it will be returned with the access code.

https://api.wizardsoft.com/core?response_type=code&client_id={client_id}&redirect_uri={redirect_uri}&scope={scope}&state={state}

If the authorization was successful, the user will be redirected back to the redirect_uri along with a token in the query string value code.

The next step is to exchange your authorization code for a token. You'll need to pass the authorization code received to the token endpoint (https://api.wizardsoft.com/core/token) using POST and include the following items in the query string.

1. client_id - The API key provided to you by `WizardSoft`.
2. client_secret - The API secret provided to you by `WizardSoft`.
3. grant_type - The grant type you are requesting, in this case, the value should always be 'authorization_code',
4. code - The code that was returned in the authorization code request.
5. redirect_uri - The redirect URI used in your call to the authorization endpoint.

When this call is made successfully an access token, refresh token and token expiry will be passed back in JSON format:
1. `access_token` - The user access token.
2. `refresh_token`- The user refresh token. This can be used to request a new access token on the user's behalf.
3. `expires_in` - How long until the access token expires. Access tokens will expire after 24 hours and refresh tokens will expire after 48 hours.

Accessing End points You can now use this access token to create, read and update data on a user's behalf. When making a request to an API endpoint ensure that the following headers are set:

`Accept: application/json`
`Authorization: Bearer {YOUR_ACCESS_TOKEN}`

For example making a request to any endpoint ex. https://api.wizardsoft.com/sandbox/demoapi with set the headers of authorization which will return the data of sample data of demo api. 

**Note: If you do not pass the accept header the API will not give you access to the endpoint!**

