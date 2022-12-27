import axios from "axios";
const InstanceDatosMedicosAxios = axios.create({ baseURL: "https://localhost:7243/Product" });
const headerConfig = {
  headers: {
    "Content-Type": "application/json",
    accept: "application/json",
  },
};

export const getProductos = (param) => {
  return InstanceDatosMedicosAxios.get(`/${param}`, headerConfig)
    .then((response) => {
      return response.data;
    })
    .catch((error) => {
      throw error;
    });
};

export const putProducto = (param) => {
  const data = JSON.stringify(param);
  return InstanceDatosMedicosAxios.put("",data, headerConfig)
    .then((response) => {
      return response.data;
    })
    .catch((error) => {
      throw error;
    });
};

export const postProducto = (param) => {
  const data = JSON.stringify(param);
  return InstanceDatosMedicosAxios.post("",data, headerConfig)
    .then((response) => {
      return response.data;
    })
    .catch((error) => {
      throw error;
    });
};

export const deleteProducto = (param) => {
  const data = JSON.stringify(param);
  console.log();
  return InstanceDatosMedicosAxios.delete(`?id=${param}`,headerConfig)
    .then((response) => {
      console.log(data);
      return response.data;
    }) 
    .catch((error) => {
      console.log("error catched");
      throw error;
    });
};
