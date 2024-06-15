import { useState } from "react";
import { Button, Form, FormGroup, Input, Label } from "reactstrap";
import { addNewCard } from "../../managers/paymentDetailsManager.js";

export default function AddCardForm({loggedInUser})
{
    const [cardName, setCardName] = useState("")
    const [cardNumber, setCardNumber] = useState(0)
    const [cardExpiration, setCardExpiration] = useState()

    const handleSubmit = (e) => {
        e.preventDefault()

        const newCard = {
            UserProfileId: loggedInUser.id,
            CreditCardNumber:cardNumber,
            CreditCardExpiration: cardExpiration
        }
        addNewCard(newCard)

    }
    return(
        <Form className="w-50 m-auto mt-4" onSubmit={handleSubmit}>
            <FormGroup>
                <Label className="fw-bold">Name on Card</Label>
                <Input onChange={(e) => {setCardName(e.target.value)}}/>
            </FormGroup>
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