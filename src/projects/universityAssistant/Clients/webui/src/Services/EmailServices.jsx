import axios from "axios";
import { toast } from "react-toastify";

export default class EmailServices {
    
  SendEmailConfirmation() {
    return axios
      .get(process.env.REACT_APP_API_URL + "/Users/SendEmailConfirmation", {
        headers: {
          Authorization: `bearer ${localStorage.getItem("token")}`,
        },
      })
      .then((res) => {
        console.log(res);
        toast.success(res.data.message);
      })
      .catch((err) => toast.error(err.response.data.Detail));
  }

  ConfirmEmail(code) {
    return axios
      .get(
        process.env.REACT_APP_API_URL +
          `/Users/ConfirmEmailAddressWithKeyOrCode?KeyOrCode=${code}`,
        {
          headers: {
            Authorization: `bearer ${localStorage.getItem("token")}`,
          },
        }
      ) 
  }
}
