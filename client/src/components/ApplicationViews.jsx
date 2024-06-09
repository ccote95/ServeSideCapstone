import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import AllListings from "./Listings/AllListings.jsx";
import LandingPage from "./LandingPage.jsx";


export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
             <LandingPage loggedInUser={loggedInUser}/>
            </AuthorizedRoute>
          }
        />
        <Route path="listings">
          <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <AllListings loggedInUser={loggedInUser}/>
            </AuthorizedRoute>
          }
        />
        </Route>
      
        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}
