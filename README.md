# .NetCoreWebAPITemplate
.Net Core 2.2 WebApi with JWT Auth with MSSQL DB.

Setup needed:
1. Models folder has a template for a WebUser class with basic user properties. Entity Framework needs a connection to a MSSQL, either scaffold to an existing database or use code first to build a new database for your user auth details.
2. Your DB Context will need to be referenced in UserService.cs to start using your database for authentication.
3. JWT Secret, you will need to update a unique secret key for the JWT generation and validation. This is set in appsettings.json
4. A MailHelper class was added to allow sending of emails using office365 email account. Update Credentials in Helpers/MailHelper.cs
5. PDF Template Generator has an example of html string for a test PDF through PDFController
