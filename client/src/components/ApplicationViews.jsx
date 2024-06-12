import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import AllListings from "./Listings/AllListings.jsx";
import LandingPage from "./LandingPage.jsx";
import ListingDetails from "./Listings/ListingDetails.jsx";
import CreateListing from "./Listings/CreateListing.jsx";
import ListingForm from "./Listings/ListingForm.jsx";
import MyListings from "./Listings/MyListings.jsx";
import MyProfile from "./UserProfile/MyProfile.jsx";


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
          <Route path=":id">
            <Route
              index
              element={
                <AuthorizedRoute loggedInUser={loggedInUser}>
                  <ListingDetails loggedInUser={loggedInUser}/>
                </AuthorizedRoute>
              }
            />
            <Route
              path="edit"
              element = {
                <AuthorizedRoute loggedInUser={loggedInUser}>
                  <ListingForm loggedInUser={loggedInUser}/>
                </AuthorizedRoute>
              }
            />
          </Route>
          <Route path="create">
            <Route
              index
              element={
                <AuthorizedRoute loggedInUser={loggedInUser}>
                  <CreateListing loggedInUser={loggedInUser}/>
                </AuthorizedRoute>
              }
          />
        </Route>
        <Route path="myListings">
          <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <MyListings loggedInUser={loggedInUser}/>
              </AuthorizedRoute>
            }
          />
        </Route>
      </Route>
      <Route path="myProfile">
            <Route 
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <MyProfile loggedInUser={loggedInUser}/>
              </AuthorizedRoute>
            }/>
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
