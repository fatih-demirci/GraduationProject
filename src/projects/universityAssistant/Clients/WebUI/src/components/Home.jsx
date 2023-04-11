import React from "react";
import { Route, Routes } from "react-router-dom";
import HomePage from "./HomePage/HomePage";
import PopupComponent from "./common/popupBox/PopupComponent";
import Navbar from "./common/Navbar/Navbar"
import Signin from "./SignIn/Signin";
import Signup from "./SignUp/Signup";
import Profile from "./Profile/Profile";
import Decor from "./common/Decor/Decor";
import ForumPage from "./ForumPage/ForumPage";
import UniversityGuide from "./UniversityGuide/UniversityGuide";
import UniversityGuideList from "./UniversityGuideList/UniversityGuideList";
import UniversityDetailPage from "./UniversityDetailPage/UniversityDetailPage";
import UniversitySharesPostDetail from "./UniversitySharesPostDetail/UniversitySharesPostDetail";

const Home = () => {
  return (
    <>
        <Navbar />
      <Decor/>

        <Routes>
          <Route path="/" element={<HomePage/>}></Route>
          <Route path="/signin" element={<Signin/>}></Route>
          <Route path="/signup" element={<Signup/>}></Route>
          <Route path="/profile" element={<Profile/>}></Route>
          <Route path="/forum" element={<ForumPage/>}></Route>
          <Route path="/university-guide" element={<UniversityGuide/>}></Route>
          <Route path="/university-guide/:id" element={<UniversityGuideList/>}></Route>
          <Route path="/university-guide/:id/:name" element={<UniversityDetailPage/>}></Route>
          <Route path="/university-guide/:id/:name/sharing/:id" element={<UniversitySharesPostDetail/>}></Route>
        </Routes>
        

    </>
  );
};

export default Home;
