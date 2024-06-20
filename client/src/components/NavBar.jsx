import { useEffect, useState } from "react";
import { NavLink as RRNavLink } from "react-router-dom";
import {
Button,
Collapse,
Nav,
NavLink,
NavItem,
Navbar,
NavbarBrand,
NavbarToggler,
} from "reactstrap";
import { logout } from "../managers/authManager";
import ShoppingCartCount from "./ShoppingCart/ShoppingCartCount.jsx";
import { getAllCartsById } from "../managers/shoppingCartManager.js";

export default function NavBar({ loggedInUser, setLoggedInUser, cartItemCount }) {
const [open, setOpen] = useState(false);


const toggleNavbar = () => setOpen(!open);





return (
    <div>
    <Navbar color="light" light fixed="true" expand="lg">
        <NavbarBrand className="mr-auto" tag={RRNavLink} to="/">
        📜ChadsList 
        </NavbarBrand>
        {loggedInUser ? (
        <>
            <NavbarToggler onClick={toggleNavbar} />
            <Collapse isOpen={open} navbar>
            <Nav navbar>
                <NavItem>
                    <NavLink tag={RRNavLink} to="/listings">
                        Listings
                    </NavLink>
                </NavItem>
                <NavItem>
                    <NavLink tag={RRNavLink} to ="/listings/myListings">
                        My Listings
                    </NavLink>
                </NavItem>
                <NavItem>
                    <NavLink tag={RRNavLink} to = "/myProfile">
                        My Profile
                    </NavLink>
                </NavItem>
            </Nav>
            </Collapse>
            <Nav>
                <NavItem>
                    <NavLink className="me-4" tag={RRNavLink} to="/shoppingCart">
                <ShoppingCartCount loggedInUser={loggedInUser} count={cartItemCount}/>
                    </NavLink>
                </NavItem>

            </Nav>
            <Button
            color="primary"
            onClick={(e) => {
                e.preventDefault();
                setOpen(false);
                logout().then(() => {
                setLoggedInUser(null);
                setOpen(false);
                });
            }}
            >
            Logout
            </Button>
        </>
        ) : (
        <Nav navbar>
            <NavItem>
            <NavLink tag={RRNavLink} to="/login">
                <Button color="primary">Login</Button>
            </NavLink>
            </NavItem>
        </Nav>
        )}
    </Navbar>
    </div>
);
}