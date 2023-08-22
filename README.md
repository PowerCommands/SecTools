# PainKiller Security Tools

This repo contains a Power Command Console project with different commands with some kind of security purpose

# Prerequisites
You need DockerDesktop or equivalent software installed to run Cdxgen Sbom creation.

## Dockerdesktop
Start docker desktop on your machine if it´s not already started
```cdxgen```

## Cdxgen 
Start Cdxgen server to create sbom content, this will spin up the docker container for you.
```cdxgen```

## Sbom
Create sbom content from a local path or github repository

**Local path**
```sbom --path <local path>```
**Github repository**
```sbom --path https://github.com/PowerCommands/PowerCommands2022.git```

Read more about SBOM: https://www.cisa.gov/sbom
