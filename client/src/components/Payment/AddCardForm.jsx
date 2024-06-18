import { useEffect, useState } from "react";
import { Button, Form, FormGroup, Input, Label } from "reactstrap";
import { addNewCard, getByCardsId, updateCardDetails } from "../../managers/paymentDetailsManager.js";
import { useNavigate, useParams } from "react-router-dom";
import Cleave from "cleave.js/react";

export default function AddCardForm({loggedInUser})
{
    const {id} = useParams()
  
    const [cardNumber, setCardNumber] = useState("")
    const [cardExpiration, setCardExpiration] = useState()

    const navigate = useNavigate()
    
    const formatDate = (date) => {
        const d = new Date(date);
        const year = d.getFullYear();
        const month = (d.getMonth() + 1).toString().padStart(2, '0');
        const day = d.getDate().toString().padStart(2, '0');
        return `${year}-${month}-${day}`;
    };

     useEffect(() => {
        if(id)
            {
                getByCardsId(parseInt(id)).then(card => {
                    setCardNumber(card.creditCardNumber)
                    setCardExpiration(card.creditCardExpiration.toString("MM,dd,yyy"))
                })
            }
    },[id])

    const handleSubmit = (e) => {
        e.preventDefault()
        const card = {
            UserProfileId: loggedInUser.id,
            CreditCardNumber:cardNumber,
            CreditCardExpiration: cardExpiration
        }
        if(id){
            updateCardDetails(id,card).then(() => {navigate("/myProfile/paymentInfo")})
        }
        else{

            addNewCard(card).then(() => {navigate("/myProfile/paymentInfo")})
        }

    }
    return(
        <Form className="w-50 m-auto mt-4" onSubmit={handleSubmit}>
            <FormGroup>
                <Label className="fw-bold">Card Number</Label>
                <Cleave
                    value={cardNumber}
                    options={{ creditCard: true }}
                    onChange={(e) => setCardNumber(e.target.rawValue)}
                    className="form-control"
                    placeholder="1234 5678 9012 3456"
                />
            </FormGroup>
            <FormGroup>
                <Label className="fw-bold">Card Expiration Date</Label>
                <Input 
                    value={formatDate(cardExpiration)} 
                    type="date" 
                    onChange={(e) => {setCardExpiration(e.target.value)}}
                />
            </FormGroup>
            <Button color="primary" type="submit" style={{float: "right"}}>Save</Button>
        </Form>
    )
}