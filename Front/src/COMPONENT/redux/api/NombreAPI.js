import axios from "axios";
const InstanceHallazgosAxios = axios.create({ baseURL: "https://localhost:7243/User" });
const headerConfig = {
  headers: {
    "Content-Type": "application/json",
    accept: "application/json",
    authorization: "Bearer" + window.localStorage.getItem("access_token"),
  },
};

export const getNombre = (param) => {
  return InstanceHallazgosAxios.get(``, headerConfig)
    .then((response) => {
      return response.data;
    })
    .catch((error) => {
      throw error;
    });
};
