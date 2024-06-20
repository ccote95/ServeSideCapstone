import { useEffect, useState } from "react"
import {  getAllCartsById, removeItemFromCart } from "../../managers/shoppingCartManager.js"
import PageContainer from "../FlexContainer.jsx"
import { Button, Card, CardBody, CardFooter, CardHeader } from "reactstrap"
import { getById } from "../../managers/userProfileManager.js"
import { useNavigate } from "react-router-dom"
import ConfirmDelete from "../PopUps/ConfirmDelete.jsx";

export default function ShoppingCart({loggedInUser, setCartItemCount})
{
    const [cart, setCart] = useState()
    const [total, setTotal] = useState(0)
    const [user, setUser] = useState()
    const [itemToDelete, setItemToDelete] = useState(null);
    const [isModalOpen, setIsModalOpen] = useState(false)

    const navigate = useNavigate()



    useEffect(() => {
        getAllCartsById(loggedInUser.id).then(setCart)
        getById(loggedInUser.id).then(setUser)
    },[loggedInUser])

    useEffect(() => {
        let cartTotal = 0

        cart?.map((c) => {
            cartTotal += c.total
        })
        setTotal(cartTotal.toFixed(2));
        setCartItemCount(cart?.length)
    },[cart, setCartItemCount])

    const refresh = () => {
        getAllCartsById(loggedInUser.id).then(setCart)
    }
    
    const handleRemoveItem = (id) => {
        removeItemFromCart(id,loggedInUser.id).then(() => {refresh()})
    }

    const handleConfirmDelete = () => {
        if (itemToDelete) {
            handleRemoveItem(itemToDelete);
            setIsModalOpen(false);
            setItemToDelete(null);
        }
    };

    const toggleModal = () => {
        setIsModalOpen(!isModalOpen)
    }

    const openConfirmDeleteModal = (id) => {
        setItemToDelete(id);
        setIsModalOpen(true);
    };


    return(
        <PageContainer>
          <Card className="w-50 shadow">
            <CardHeader>
            <h3 >{user?.fullName}'s Cart</h3>
            </CardHeader>
            <CardBody>
                {cart?.map((c) => {
                    return <div key={c.id} className="d-flex justify-content-between mb-1">
                        <div className=" fs-4 w-50">
                        {c.listing.title} 
                        </div>
                        <div className="fw-bold">
                        ${c.listing.price}
                        </div>
                        <div className="mb-1">
                        <Button color="danger" onClick={() => { openConfirmDeleteModal(c.id)}}>Remove</Button>
                        </div>
                    </div>
                })}
            </CardBody>
            <CardFooter>
                <div className="d-flex justify-content-between align-items-center">
                    <div className="fw-bold">
                        Your Total: ${total}
                    </div>
                    <div>
                <Button onClick={() => {navigate("checkout")}} color="primary" >Proceed to Checkout</Button>
                    </div>
                </div>
            </CardFooter>
          </Card>
          <ConfirmDelete 
          isOpen={isModalOpen}
          toggle={toggleModal}
          confirmDelete={handleConfirmDelete}
          typeName={"Item"}/>
          
        </PageContainer>
    )
    
}