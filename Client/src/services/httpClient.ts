import axios ,{ AxiosInstance}  from 'axios';
import {SiteConfig} from './../config/siteConfig';

declare interface IhttpRequestConfigs
{
    baseURL?: string;
    data?:Record<string,unknown>;
    headers?:Record<string,unknown>;
    method?: 'GET'|'POST'|'PUT'|'PATCH'|'DELETE';
    url?:string;
    params?:Record<string,unknown>;
    timeout?:number;
}

const defaultRequestConfig:IhttpRequestConfigs ={
    baseURL :SiteConfig.HackathonCSAPIUrl,
    headers:{},
    method:'GET',
    timeout:1200000
}

export const createHttpClient =(configs:IhttpRequestConfigs = {}):AxiosInstance => {

    const axiosConfigs = { ...defaultRequestConfig , ...configs};
    const {data,headers,method} =configs;

    return axios.create({
        ...axiosConfigs,
        headers:{
            'Access-Control-Allow-Origin': '*' ,'Content-Type' : 'application/json' , 'Accept':'application/json',...headers
        },
    });
}

export function Request(obj:any)
{
    let config : any =defaultRequestConfig;
    config.url =obj.url;
    config.method = obj.method;
    config.data = ['POST','PUT','DELETE','PATCH'].includes(obj.method)?obj.data:null;
    config.params = obj.params;
    let instance = createHttpClient(config);
    console.log(config);
    return instance.request(config);
    
}