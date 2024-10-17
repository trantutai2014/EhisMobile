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
  server: {
    url: 'http://192.168.0.106', // Địa chỉ IP của máy chủ API/WebSocket
    cleartext: true // Cần thiết nếu bạn đang dùng HTTP không bảo mật trên Android
  }
};

import { CapacitorHttp, HttpResponse } from '@capacitor/core';

// Example of a GET request
const doGet = async () => {
  const options = {
    url: 'http://192.168.0.106/',
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
    url: 'http://192.168.0.106/',
    headers: { },
    data: {},
  };

  const response: HttpResponse = await CapacitorHttp.post(options);

  // or...
  // const response = await CapacitorHttp.request({ ...options, method: 'POST' })
};
export default config;