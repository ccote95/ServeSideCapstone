import { useEffect, useState } from "react"
import {  getAllCartsById } from "../../managers/shoppingCartManager.js"
import PageContainer from "../FlexContainer.jsx"
import { Card, CardBody, CardFooter, CardHeader } from "reactstrap"

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
          <Card>
            <CardBody>
                {cart?.map((c) => {
                    return <p>
                        {c.listing.title} ${c.listing.price}
                    </p>
                })}
            </CardBody>
            <CardFooter>
                {total}
            </CardFooter>
          </Card>
        </PageContainer>
    )
    
}