import { useEffect, useState } from "react"
import { getAllCartsById } from "../../managers/shoppingCartManager.js"
import { getById } from "../../managers/userProfileManager.js"
import { useNavigate } from "react-router-dom"
import PageContainer from "../PageContainer.jsx"
import { Button, Card, CardBody, CardFooter, CardHeader, CardText, Input, Label } from "reactstrap"
import { getAllByUserId } from "../../managers/paymentDetailsManager.js"
import { placeOrder } from "../../managers/placedOrderManager.js"
import CustomToast from "../PopUps/AddingToCartToast.jsx"

export default function Checkout({loggedInUser})
{
    const [cart, setCart] = useState()
    const [total, setTotal] = useState(0)
    const [user, setUser] = useState()
    const [cards, setCard] = useState()
    const [chosenCard, setChosenCard] = useState()
    const [toastOpen, setToastOpen] = useState(false);
    const [toastMessage, setToastMessage] = useState('');
    const [isFailed, setIsFailed]= useState(false)

    const navigate = useNavigate()



    useEffect(() => {
        getAllCartsById(loggedInUser.id).then(setCart)
        getById(loggedInUser.id).then(setUser)
        getAllByUserId(loggedInUser.id).then(setCard)
    },[loggedInUser])

    useEffect(() => {
        let cartTotal = 0

        cart?.map((c) => {
            cartTotal += c.total
        })
        setTotal(cartTotal);
    },[cart])

    const toggleToast = () => setToastOpen(!toastOpen);

        // Function to mask the credit card number
    const maskCreditCardNumber = (number) => {
        const str = number.toString();
        const last4 = str.slice(-4);
        return '**** **** **** ' + last4;
    };

    const handlePlaceOrder =  () => {
        let success = false
        placeOrder(chosenCard,cart, loggedInUser.id).then((res) => {
            if(res.status === 400)
                {
                    setToastMessage("Failed to process order!");
                    setToastOpen(true);
                    setIsFailed(true);
                    return 
                }
            setToastMessage("Order successfully placed!");
            setToastOpen(true);
            success = true;
        });
         
            
        
         // Automatically close the toast after 3 seconds
        setTimeout(() => {
            setToastOpen(false);
            if(success){
                navigate("/listings")
            }
        }, 3000);
    }

        


    return(
        <PageContainer>
            <Card className="w-25">
                <CardHeader>
                    Confirm Details
                </CardHeader>
                <CardBody>
                <div className="d-flex">
                        <Label>Full Name:</Label>
                        <CardText className="ms-1">{user?.fullName}</CardText>
                    </div>
                    <div className="d-flex">
                        <Label>Address:</Label>
                        <CardText className="ms-1">{user?.address}</CardText>
                    </div>
                </CardBody>
                <CardBody>
                    <Input
                        type="select"
                        onChange={(e) => {setChosenCard(parseInt(e.target.value))}}
                    >
                        <option value={0}>Choose Payment</option>
                        {cards?.map((c) => (
                            <option key={c.id} value={c.id}>{maskCreditCardNumber(c.creditCardNumber)}</option>
                        ))}
                    </Input>
                </CardBody>
                <CardFooter>
                <div className="d-flex justify-content-between align-items-center">
                    <div className="fw-bold">
                        Your Total: ${total}
                    </div>
                    <div>
                <Button onClick={handlePlaceOrder} color="primary" >Place Order</Button>
                    </div>
                    <CustomToast isFailed={isFailed} isOpen={toastOpen} toggle={toggleToast} message={toastMessage} />
                </div>
                </CardFooter>
            </Card>
        </PageContainer>
    )
}