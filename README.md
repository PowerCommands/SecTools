# PainKiller Security Tools
<img src="logo.png" alt="cdxgen" width="512">

This repo contains a Power Command Console project with different commands with some kind of security purpose

# Prerequisites
If this is the first time you use a Power Commands implementation a encryption setup will be done at the first startup. The encryption key is setup for all Power Commands projects and is unique for every machine. Encryption is used by this Power Commands project to secure your **Dependency Track** API key.

This application is intended to use **CycloneDX** and **Dependency Track** software running as container, therefore you need to have Docker Desktop installed, this way you do not need to install software on your machine besides this Power Commands console application. Setup Docker Desktop is however not described in this documentation. 

If you want to setup **CycloneDX** and **Dependency Track** in any other way, I recommend you to look at their respective documentation, links to their repos are present at the end of this document. You also need to adjust the ```PowerCommandsConfiguration.yaml``` configuration file with the appropriate API endpoints. You do not need to run the ```start``` command if the software is installed and already running on your machine or a server else where.

## Start
```start```

**The following steps will be done by the ```start``` command**
 - Starts docker desktop on your machine if it´s not already started ()
 - Start Cdxgen server to create sbom content, this will spin up the docker container for you. Make sure that you set the property ```sdxGenServerVolumeMount``` in the ```PowerCommandsConfiguration.yaml``` configuration file first.
 - Download ```docker-compose.yaml file```, path must be set in configuration file, if the file is already downloaded, this step will be skipped, that way you can change settings in the compose file if you want.
 - Start the Dependency Tracker Web GUI and API server. (Docker container) default url is: http://localhost:8080 login with ```admin```:```admin```

 NOTICE! The first time you run startup the containers needed to run by DockerDesktop on your machine will be downloaded, this could take some time, but you see the process in the console, have patience with that. 

## Good to know, before you creating Sbom files...
You can create the files and add them to **Dependency Track** manually in the GUI. But if you configure **Dependency Track** and **PowerCommands** you been able to us the ```--upload``` option flag and with that the sbom content is automatically uploaded to **Dependency Track**. First tou need to create a **Team** in the **Administration/Access Management** section, and add at least the permission that is shown in the image below.  

<img src="dt-api-key.png" alt="cdxgen" width="512">

After that copy the API key and create a secret in PowerCommands with this command.

```secret --create "DT_PowerCommand"```

After this configuration sbom will be uploaded to **Dependency Track**.

## Sbom
Create sbom content from a local path or github repository

**Local path**

```sbom --path <local path> --NAME <my-sbom-name>```

**Github repository**

Please notice that https://github.com/PowerCommands/PowerCommands2022.git is just for the example, you can point at any git repository, I do not think that my Power Commands repo is that interesting for you.

```sbom --path https://github.com/PowerCommands/PowerCommands2022.git --NAME <my-sbom-name>```

### --upload
If you add the --upload option, the sbom will also be uploaded to Dependency Tracker, a new project with the --NAME value will be created. 

```sbom --path https://github.com/PowerCommands/PowerCommands2022.git --NAME <my-sbom-name> --upload```

___

## Power Commands

Read more about Power Commands: https://github.com/PowerCommands/PowerCommands2022

Read more about SBOM: https://www.cisa.gov/sbom

## CycloneDX Generator
<img src="cdxgen.png" alt="cdxgen" width="128">

[CycloneDX Generator](https://github.com/CycloneDX/cdxgen) on github. 

## Dependency Track
<img src="dt-logo.svg" alt="Dependency Track logo" width="256">

[Dependency Track](https://github.com/CycloneDX/cdxgen) on github. 
