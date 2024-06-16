import { useEffect, useState } from "react";
import { Button, Form, FormGroup, Input, Label } from "reactstrap";
import { addNewCard } from "../../managers/paymentDetailsManager.js";
import { useNavigate, useParams } from "react-router-dom";

export default function AddCardForm({loggedInUser})
{
    const {id} = useParams()
  
    const [cardNumber, setCardNumber] = useState(0)
    const [cardExpiration, setCardExpiration] = useState()

    const navigate = useNavigate()

     useEffect(() => {

    },[id])

    const handleSubmit = (e) => {
        e.preventDefault()

        const newCard = {
            UserProfileId: loggedInUser.id,
            CreditCardNumber:cardNumber,
            CreditCardExpiration: cardExpiration
        }
        addNewCard(newCard).then(() => {navigate("/myProfile/paymentInfo")})

    }
    return(
        <Form className="w-50 m-auto mt-4" onSubmit={handleSubmit}>
            <FormGroup>
                <Label className="fw-bold">Card Number</Label>
                <Input onChange={(e) => {setCardNumber(e.target.value)}}/>
            </FormGroup>
            <FormGroup>
                <Label className="fw-bold">Card Expiration Date</Label>
                <Input type="date" onChange={(e) => {setCardExpiration(e.target.value)}}/>
            </FormGroup>
            <Button color="primary" type="submit" style={{float: "right"}}>Save</Button>
        </Form>
    )
}