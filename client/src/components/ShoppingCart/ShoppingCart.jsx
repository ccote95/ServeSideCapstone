import { useEffect, useState } from "react"
import {  getAllCartsById } from "../../managers/shoppingCartManager.js"

export default function ShoppingCart({loggedInUser})
{
    const [cart, setCart] = useState()

    useEffect(() => {
        getAllCartsById(loggedInUser.id).then(setCart)
    },[])
    return(
        <div>hello</div>
    )
}