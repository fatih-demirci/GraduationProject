import axios from "axios";

export default class UniversityServices {
  UniversityListFilterProvienceId(provienceId) {
    return axios.get(
      process.env.REACT_APP_API_URL +
        `/Universities/?culture=tr-TR&count=true&select=id,provienceId,provienceName,countryId,name,LogoURL&filter=provienceId eq ${provienceId}`
    );
  }
  UniversityInfoDetail(id) {
    return axios.get(
      process.env.REACT_APP_API_URL +
        `/Universities/?culture=tr-TR&count=true&select=id,provienceId,provienceName,countryId,countryName,name,website,email,phone,fax,address,type,LogoURL&filter=Id eq ${id}`
    );
  }
  AddUniversityComment(universityId, title, message, file) {
    return axios.post(
      process.env.REACT_APP_API_URL +
        `/PostUniversityComments/AddUniversityComment`,
      {
        UniversityId: universityId,
        Title: title,
        Message: message,
        FormFiles: file,
      },
      {
        headers: {
          "Content-Type": "multipart/form-data",
          Authorization: `bearer ${localStorage.getItem("token")}`,
        },
      }
    );
  }

  GetUniversityComment(id) {
    return axios.get(
      process.env.REACT_APP_API_URL +
        `/UniversityComments/?count=true&expand=User,UniversityCommentFiles&skip=0&top=100&filter=UniversityId eq ${id}`
    );
  }
  GetUniversityCommentDetail(id) {
    return axios.get(
      process.env.REACT_APP_API_URL +
        `/UniversityComments/?count=true&expand=User,UniversityCommentFiles&skip=0&top=100&filter=Id eq ${id}`
    );
  }
}
