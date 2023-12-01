import axios from "axios";
import Result from "../types/Result";

const baseUrl = "http://localhost:5078/api";

const apiHelper = {
  get: <T>(endpoint:string):Promise<T> => {
    return new Promise((resolve,reject) => {
      axios.get(`${baseUrl}/${endpoint}`).then((response) => {
        const result: Result<T> = response.data;
        if (result.isSuccess) {
          resolve(result.data ?? ({} as T));
        }
        else {
          reject(result.message)
        }
      });
    })
  }
}

export default apiHelper;