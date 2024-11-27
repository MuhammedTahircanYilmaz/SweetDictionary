namespace Core.Tokens.Configuration;

public class CustomTokenOptions
{
    public string Issuer { get; set; } // Issuer is the Url from which the Api access is carried out
    public List<string> Audience { get; set; } // Audience is a list of End Points (URL's) that are allowed to access the Api
    public int AccessTokenExpiration { get; set; } // AccessTokenExpiration shows the time period where the token has
                                                   // access to the Api before the user has to re-login 
    public string  SecurityKey { get; set; } // through SecurityKey, the signature part of a JWT token is encoded during
                                             // the creation of a token.
                                            // By checking the before and after signature of a token, we can see if a
                                            // third party has tempered with the header or payload of a token
}
