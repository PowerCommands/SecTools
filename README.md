# PainKiller Security Tools

This repo contains a Power Command Console project with different commands with some kind of security purpose

# Prerequisites
You need DockerDesktop or equivalent software installed to run Cdxgen Sbom creation.

## Start
```start```
 - Starts docker desktop on your machine if it´s not already started
 - Start Cdxgen server to create sbom content, this will spin up the docker container for you. Make sure that you set the property ```sdxGenServerVolumeMount``` in the ```PowerCommandsConfiguration.yaml``` configuration file first.
 - Download ```docker-compose.yaml file```, path must be set in configuration file, if the file is already downloaded, this step will be skipped, that way you can change settings in the compose file if you want.
 - Start the Dependency Tracker Web GUI and API server. (Docker container) default url is: http://localhost:8080 login with ```admin```:```admin```

## Sbom
Create sbom content from a local path or github repository

**Local path**

```sbom --path <local path>```

**Github repository**

```sbom --path https://github.com/PowerCommands/PowerCommands2022.git```

Read more about SBOM: https://www.cisa.gov/sbom

## CycloneDX Generator
<img src="cdxgen.png" alt="cdxgen" width="128">

[CycloneDX Generator](https://github.com/CycloneDX/cdxgen) on github. 

## Dependency Track
<img src="dt-logo.svg" alt="Dependency Track logo" width="256">

[Dependency Track](https://github.com/CycloneDX/cdxgen) on github. 
