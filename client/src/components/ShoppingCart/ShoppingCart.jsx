import { useEffect, useState } from "react"
import {  getAllCartsById } from "../../managers/shoppingCartManager.js"
import PageContainer from "../FlexContainer.jsx"
import { Button, Card, CardBody, CardFooter, CardHeader } from "reactstrap"

export default function ShoppingCart({loggedInUser})
{
    const [cart, setCart] = useState()
    const [total, setTotal] = useState(0)



    useEffect(() => {
        getAllCartsById(loggedInUser.id).then(setCart)
    },[])

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
            <CardBody>
                {cart?.map((c) => {
                    return <p className="fw-bold">
                        {c.listing.title} ${c.listing.price}
                    </p>
                })}
            </CardBody>
            <CardFooter>
                <div className="d-flex justify-content-between align-items-center">
                    <div className="fw-bold">
                        ${total}
                    </div>
                    <div>
                <Button   >Place Order</Button>
                    </div>
                </div>
            </CardFooter>
          </Card>
        </PageContainer>
    )
    
}