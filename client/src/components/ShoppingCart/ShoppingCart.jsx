import { useEffect, useState } from "react"
import {  getAllCartsById } from "../../managers/shoppingCartManager.js"
import PageContainer from "../FlexContainer.jsx"
import { Button, Card, CardBody, CardFooter, CardHeader } from "reactstrap"
import { getById } from "../../managers/userProfileManager.js"

export default function ShoppingCart({loggedInUser})
{
    const [cart, setCart] = useState()
    const [total, setTotal] = useState(0)
    const [user, setUser] = useState()



    useEffect(() => {
        getAllCartsById(loggedInUser.id).then(setCart)
        getById(loggedInUser.id).then(setUser)
    },[loggedInUser])

    useEffect(() => {
        let cartTotal = 0

        cart?.map((c) => {
            cartTotal += c.total
        })
        setTotal(cartTotal);
    },[cart])
    
    return(
        <PageContainer>
          <Card className="w-25">
            <CardHeader>
            <h3 >{user?.fullName}'s Cart</h3>
            </CardHeader>
            <CardBody>
                {cart?.map((c) => {
                    return <div key={c.id} className="d-flex justify-content-between mb-1">
                        <div className=" fs-4">
                        {c.listing.title} 
                        </div>
                        <div className="fw-bold">
                        ${c.listing.price}
                        </div>
                        <div className="mb-1">
                        <Button>Remove</Button>
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
                <Button   >Proceed to Checkout</Button>
                    </div>
                </div>
            </CardFooter>
          </Card>
        </PageContainer>
    )
    
}