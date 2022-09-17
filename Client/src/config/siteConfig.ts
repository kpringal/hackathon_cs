import config from './config.json'

export class SiteConfig{
    public static HackathonCSAPIUrl :string
}

export const ConfigureSite = async()=>{

    const json = config;

    SiteConfig.HackathonCSAPIUrl =json.HackathonCS.HackathonCSAPIUrl;

}

ConfigureSite();