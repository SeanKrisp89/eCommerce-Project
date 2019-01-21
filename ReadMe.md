# To Run the Application

1. Clone the repository to your local machine

2. Navigate to the application location on your local machine via the command line and enter the next four commands:

	2.A: dotnet restore                  -----> restores nuget packages
	2.B: dotnet build                    -----> builds application
	2.C: dotnet ef database update       -----> builds out application db
	2.D: dotnet run                      -----> runs startup



## SendGrid configuration 
This application requires that a SendGrid API key be set before the email services are enabled. You'll need to secure a SendGrid API key from your
SendGrid account in order to activate the services. Enter the API key in place of the (YOUR API KEY HERE) 

dotnet user-secrets set "SendGrid:Key" "SG.xxxxxxxxxxx"









dotnet restore, - restores buget packages
dotnet build, - builds application
dotnet ef database update - updates & builds db? 
dotnet run - runs startup