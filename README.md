# PublicAPI.Samples

Welcome to Recruit Wizard API documentation. It is an OAuth 2.0 API that uses the Authorization code workflow to authorize users.

Full Swagger Documentation can be [found here](https://api.recruitwizard.com/swagger)

You can add your `client_id` and `client_secret` fields in the web.config.

## Setup Instruction

To recieve API Access you will need to register your app [here](https://api.recruitwizard.com/RegisterApp). 

You need to provide at least one redirect url which will responsible for OAuth Redirect Callback. 

Your application registration will need to be approved by our Partner Management Team before your API Access is are activated. This usually takes roughly 48 hours.

They will be in touch if you have not already Signed the Recruit Wizard API Partner Agreement

If you require expediated access, or have any questions please contact [partners@recruitwizard.com](mailto:partners@recruitwizard.com)

## Authorization
The first step to getting one of your users connected to the API is to request an access code. Your user should be taken to our authorization code URL (https://api.recruitwizard.com/core/connect/authorize) and the following details should be included in the query string:

1. `client_id` - The API key provided to you by `Recruit Wizard`.
2. `redirect_uri` - The URL the user should be redirected back to after they've confirmed they want to give you access to the API.
3. `scope` - The scopes you wish to request separated by spaces. By default this will be `read` and `write`. You should also include `offline_access` if you require access to programtically refresh access to the Recruit Wizard API.
4. `response_type` - This should always be the value 'code'.
5. `state` - Pass a unique value in this field and it will be returned with the access code.

Example: https://api.recruitwizard.com/core/connect/authorize?response_type=code&client_id={client_id}&redirect_uri={redirect_uri}&scope=read+write&state=1234

If the authorization was successful, the user will be redirected back to the redirect_uri along with a token in the query string value code. Request a Token using your authorization code. The next step is to exchange your authorization code for a token. You'll need to pass the authorization code received to the token endpoint (https://api.recruitwizard.com/core/connect/token) using POST and include the following items in the request body:

1. `client_id` - The API key provided to you by `Recruit Wizard`.
2. `client_secret` - The API secret provided to you by `Recruit Wizard`.
3. `grant_type` - The grant type you are requesting, in this case, the value should always be 'authorization_code',
4. `code` - The code that was returned in the authorization code request.
5. `redirect_uri` - The redirect URI used in your call to the authorization endpoint.

When this call is made successfully an access token, refresh token and token expiry will be passed back in JSON format:
1. `access_token` - The user access token.
2. `refresh_token`- The user refresh token. This can be used to request a new access token on the user's behalf.
3. `expires_in` - How long until the access token expires. Access tokens will expire after 24 hours and refresh tokens will expire after 60 days.

Accessing End points You can now use this access token to create, read and update data on a user's behalf. When making a request to an API endpoint ensure that the following headers are set:

`Accept: application/json`
`Authorization: Bearer {YOUR_ACCESS_TOKEN}`

For example making a request to any endpoint ex. https://api.recruitwizard.com/sandbox/demoapi with set the headers of authorization which will return the data of sample data of demo api. 

**Note: If you do not pass the accept header the API will not give you access to the endpoint!**

Refreshing a token To stop users going through the authorization process again when their access tokens expire, you can programmatically refresh them on their behalf using the refresh token endpoint. This is the same as the authorization endpoint (https://api.recruitwizard.com/core/connect/token), except you pass a grant type of 'refresh_token' in the request body instead:

**Note: This endpoint only accepts data formated as application/x-www-form-urlencoded**

1. `client_id` - The API key provided to you by `Recruit Wizard`.
2. `client_secret` - The API secret provided to you by `Recruit Wizard`.
3. `grant_type` - The grant type you are requesting, in this case, the value should always be 'refresh_token',
4. `refresh_token` - The refresh token that was returned in the token request.

When this call is made successfully an access token, refresh token and token expiry will be passed back in JSON format:
1. `access_token` - The user access token.
2. `refresh_token`- The user refresh token. This can be used to request a new access token on the user's behalf.
3. `expires_in` - How long until the access token expires. Access tokens will expire after 24 hours and refresh tokens will expire after 60 days.
