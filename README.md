# Device Management

The Device Management is the backend API for handling the communication between our Cloud Services (IoTHub / IoTEdge) towards Bühler Insights.
The Device Management also has a different section where it handles the communication between IoT Edge and the Bühler platform.

## Setting up local development environment

In order to run this function in development environment, developer need to create local.settings.json file in their local copy of the solution.

Steps to create local.settings.json file as follows:
1.	Ensure that config\local.settings.template.json file is available.
2.	Open command prompt --> Change directory to *build* project root directory --> Run command 

```ps
dotnet run --target Common_ConfigureLocal --environment dev
```

## Managing Configuration

Project uses Key Vault secret **iot-backend-devicemanagement-secrets** to store all configuration values.

### **Setting secrets in Key Vault**

Key Vault secrets can be updated with the help of Pocket Nuke. Follow below steps to add/update configuration values in Key Vault.

**Adding custom secrets**

1. Add/update required property values in \build\KeyVaultCustomSecrets.cs.
2. Add/update the required key and value in Params array as shown below inside method ConfigureKeyVault() in \build\Build.cs.

Example: 
    
	 var customSecrets = new KeyVaultCustomSecrets(azureEnvironment.Name);

        azureServiceConfiguration.DefineAzureSecrets(s => s
            .WithCustomProperties(new (string Key, string Value)[]
            {
                ("TenantName", customSecrets.TenantName),
                ("DspServicePrincipalResource", customSecrets.DspServicePrincipalResource),          
                ("TopologyManagementApi_Uri", customSecrets.TopologyManagementApiUri),

                ...

**Adding common secrets**

Look in interface *IAzureSecretBuilder* for required method. Include respective method call as shown below.

    azureServiceConfiguration.DefineAzureSecrets(s => s
                .WithCosmosDatabase()
                .WithContainerRegistry()
                .WithIoTHub()
                .WithServiceBusNamespace()
                .WithStorageAccount()

### **Getting secrets from Key Vault**
Project support 3 different modes to manage configuration values 
- Direct
- KeyVault
- ManagedKeyVault 

#### Direct

Reading configuration values from AppSettings, preferred only for local development
environment. AppSetting in this case should be

	"SecretSource":  "Direct",

#### KeyVault

Reading configuration values from Key Valult in which service principal is used to authenticate. Can be used in both local and deployed environments.
 AppSetting in this case should be

	"SecretSource":  "KeyVault",
    "KeyVaultName":  "buhler-{env}-we-vault",
    "KeyVaultSecretName":  "iot-backend-devicemanagement-secrets",
    "ServicePrincipalId":  "xxxxxxxxxxxxxxxxx",
    "ServicePrincipalSecret":  "xxxxxxxxxxxxxxxxxx"

#### ManagedKeyVault

Reading configuration values from Key Valult in which Managed Identity is used to authenticate. Preferred option for deployed environments.
 AppSetting in this case should be

	"SecretSource":  "ManagedKeyVault",
    "KeyVaultName":  "buhler-{env}-we-vault",
    "KeyVaultSecretName":  "iot-backend-devicemanagement-secrets"

## Swagger Setup/Client Package Generation

Project GenerateSwaggerCli manages both swagger document generation and client package generation. Post build events are added to this project to manage the same. On successful build swagger.json is generated in Config folder.

## Testing build and deploy locally

Sometimes it's useful to test the build and deploy locally, use the following command (or similar):

```powershell
.\build.ps1 --target Build+Deploy --environment dev
--attach --force --AadServiceprincipalPasswordDev {PASSWORD} --ServiceprincipalPasswordDev {PASSWORD}
```

For more details on usage and debugging using pocket nuke refer [here](https://docs.devops.buhlergroup.com/iot-environment-pocket-nuke/#local-development)
and [here](https://docs.devops.buhlergroup.com/iot-environment-pocket-nuke/usage/#configuration).
