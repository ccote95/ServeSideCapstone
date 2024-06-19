import { useEffect, useState } from "react";
import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { tryGetLoggedInUser } from "./managers/authManager";
import { Spinner } from "reactstrap";
import NavBar from "./components/NavBar";
import ApplicationViews from "./components/ApplicationViews";
import { getAllCartsById } from "./managers/shoppingCartManager.js";

function App() {
  const [loggedInUser, setLoggedInUser] = useState();
  const [cartItemCount, setCartItemCount] = useState(0);
  const [cart, setCart] = useState()

  useEffect(() => {
    // user will be null if not authenticated
    tryGetLoggedInUser().then((user) => {
      setLoggedInUser(user);
    });
  }, []);

  useEffect(() => {
    if (loggedInUser) {
      getAllCartsById(loggedInUser.id).then(cart => {
        setCart(cart)
        setCartItemCount(cart.length);
      });
    }
  }, [cart, loggedInUser]);

  // wait to get a definite logged-in state before rendering
  if (loggedInUser === undefined) {
    return <Spinner />;
  }

  return (
    <>
      <NavBar loggedInUser={loggedInUser} setLoggedInUser={setLoggedInUser} cartItemCount={cartItemCount} />
      <ApplicationViews
        loggedInUser={loggedInUser}
        setLoggedInUser={setLoggedInUser}
      />
    </>
  );
}

export default App;
