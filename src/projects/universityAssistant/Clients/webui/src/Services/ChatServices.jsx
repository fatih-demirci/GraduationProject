import axios from "axios";

export default class ChatServices {

GetAllCountryCategories(){
    return axios.get(process.env.REACT_APP_API_URL + "/ChatCategories/GetAllCountryCategories?Index=1&Size=10&Status=true")

    
}
AddChatGroup(chatCategoryId,title){
    return axios.post(
        process.env.REACT_APP_API_URL + "/ChatGroups/AddChatGroup",
        {
            name:title,
          chatCategoryId:chatCategoryId,
        },
        {
          headers: {
            Authorization: `bearer ${localStorage.getItem("token")}`,
          },
        }
      );
    }
    GetAllChatGroup(id){
        return axios.get(process.env.REACT_APP_API_URL + `/ChatGroups/GetAllChatGroup?Index=1&Size=100&ChatCategoryId=${id}&Status=true`)

    }
    AddChatGroupMessage(chatCategoryId,message,file){
        return axios.post(
            process.env.REACT_APP_API_URL + "/ChatGroupMessages/AddChatGroupMessage",
            {
              chatGroupId:chatCategoryId,
              message:message,
          chatGroupMessageUrls:file

            },
            {
              headers: {
                "Content-Type": "multipart/form-data",
                Authorization: `bearer ${localStorage.getItem("token")}`,
              },
            }
          );
    }
    GetAllChatGroupMessage(id){
        return axios.get(process.env.REACT_APP_API_URL + `/ChatGroupMessages/GetAllChatGroupMessage?Index=1&Size=100&ChatGroupId=${id}&Status=true`)
    }

    GetByIdChatGroup(id){
      return axios.get(process.env.REACT_APP_API_URL + `/ChatGroups/GetByIdChatGroup?Id=${id}`)
    }
}
