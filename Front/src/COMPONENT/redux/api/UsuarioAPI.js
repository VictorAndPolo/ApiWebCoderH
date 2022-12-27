import axios from "axios";
const InstanceDatosMedicosAxios = axios.create({ baseURL: "https://localhost:7243/User" });
const headerConfig = {
  headers: {
    "Content-Type": "application/json",
    accept: "application/json",
  },
};

export const getUsuarioNombreYContraseña = (param) => {
  return InstanceDatosMedicosAxios.get(`/LogIn?username=${param.param1}&password=${param.param2}`, headerConfig)
    .then((response) => {
      return response.data;
    })
    .catch((error) => {
      throw error;
    });
};

export const getUsuarioNombre = (param) => {
  return InstanceDatosMedicosAxios.get(`/${param}`, headerConfig)
    .then((response) => {
      return response.data;
    })
    .catch((error) => {
      throw error;
    });
};

export const postUsuario = (param) => {
  return InstanceDatosMedicosAxios.post("/", param, headerConfig)
    .then((response) => {
      return response.data;
    })
    .catch((error) => {
      throw error;
    });
};

export const putUsuario = (param) => {
  const data = JSON.stringify(param);
  return InstanceDatosMedicosAxios.put("",data, headerConfig)
    .then((response) => {
      return response.data;
    })
    .catch((error) => {
      throw error;
    });
};
