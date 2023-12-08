import axios from "axios";
import Result from "../types/Result";

const baseUrl = "http://localhost:5078/api";

const apiHelper = {
  get: <T>(endpoint: string): Promise<T> => {
    return new Promise((resolve, reject) => {
      axios.get(`${baseUrl}/${endpoint}`).then((response) => {
        const result: Result<T> = response.data;
        if (result.isSuccess) {
          resolve(result.data ?? ({} as T));
        } else {
          reject(result.message);
        }
      });
    });
  },
  post: <TData, TResultData>(
    endpoint: string,
    data: TData
  ): Promise<TResultData> => {
    return new Promise((resolve, reject) => {
      axios.post(`${baseUrl}/${endpoint}`,data).then((response) => {
        const result: Result<TResultData> = response.data;
        if (result.isSuccess) {
          resolve(result.data ?? ({} as TResultData));
        } else {
          reject(result.message);
        }
      });
    });
  },

  delete: <TResultData>(
    endpoint: string
  ): Promise<TResultData> => {
    return new Promise((resolve, reject) => {
      axios.delete(`${baseUrl}/${endpoint}`).then((response) => {
        const result: Result<TResultData> = response.data;
        if (result.isSuccess) {
          resolve(result.data ?? ({} as TResultData));
        } else {
          reject(result.message);
        }
      }).catch((error) => {
        reject(error);
      });
    });
  },

};

export default apiHelper;