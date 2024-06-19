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
import EditMyProfile from "./UserProfile/EditMyProfile.jsx";
import ShoppingCart from "./ShoppingCart/ShoppingCart.jsx";
import PaymentInfo from "./Payment/PaymentInfo.jsx";
import AddCardForm from "./Payment/AddCardForm.jsx";
import Checkout from "./ShoppingCart/Checkout.jsx";
import { useEffect, useState } from "react";
import { getAllCartsById } from "../managers/shoppingCartManager.js";


export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {

  const [cartItemCount, setCartItemCount] = useState(0);
  



 
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
            <Route path="edit">
              <Route
                index
                element={
                  <AuthorizedRoute loggedInUser={loggedInUser}>
                    <EditMyProfile loggedInUser={loggedInUser}/>
                  </AuthorizedRoute>
                }
              />
            </Route>
            <Route path="paymentInfo">
              <Route
                index
                element={
                  <AuthorizedRoute loggedInUser={loggedInUser}>
                    <PaymentInfo loggedInUser={loggedInUser}/>
                  </AuthorizedRoute>
                }
              />
                <Route path=":id">
                  <Route
                    index
                    element={
                      <AuthorizedRoute loggedInUser={loggedInUser}>
                        <AddCardForm loggedInUser={loggedInUser}/>
                      </AuthorizedRoute>
                    }
                  />
                </Route>
              <Route path="addCard">
                <Route
                  index
                  element={
                    <AuthorizedRoute loggedInUser={loggedInUser}>
                      <AddCardForm loggedInUser={loggedInUser}/>
                    </AuthorizedRoute>
                  }
                />
              </Route>
            </Route>
      </Route>
      <Route path="shoppingCart">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <ShoppingCart loggedInUser={loggedInUser} setCartItemCount={setCartItemCount}/>
            </AuthorizedRoute>
          }
        />
        <Route
          path="checkout"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Checkout loggedInUser={loggedInUser}/>
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
