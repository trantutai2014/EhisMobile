import { CapacitorConfig } from "@capacitor/cli";

const config: CapacitorConfig = {
  appId: "io.ionic.starter",
  appName: "EhisMobile",
  webDir: "www",
  bundledWebRuntime: false,
  plugins: {
    CapacitorHttp: {
      enabled: true,
    },
  },
};

import { CapacitorHttp, HttpResponse } from '@capacitor/core';

// Example of a GET request
const doGet = async () => {
  const options = {
    url: 'http://192.168.0.110/',
    headers: {},
    params: {},
  };

  const response: HttpResponse = await CapacitorHttp.get(options);

  // or...
  // const response = await CapacitorHttp.request({ ...options, method: 'GET' })
};

// Example of a POST request. Note: data
// can be passed as a raw JS Object (must be JSON serializable)
const doPost = async () => {
  const options = {
    url: 'http://192.168.0.110/',
    headers: { },
    data: {},
  };

  const response: HttpResponse = await CapacitorHttp.post(options);

  // or...
  // const response = await CapacitorHttp.request({ ...options, method: 'POST' })
};
export default config;