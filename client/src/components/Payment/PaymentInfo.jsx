import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Button, Table } from "reactstrap";
import { getAllByUserId } from "../../managers/paymentDetailsManager.js";

export default function PaymentInfo({loggedInUser})
{
    const [paymentDetails, setPaymentDetails] = useState()
    const navigate = useNavigate()

    useEffect(() => {
        getAllByUserId(loggedInUser.id).then(setPaymentDetails)
    },[loggedInUser])

    return(
    <div>
        <div className="d-flex justify-content-between align-items-center mt-2 mb-3 me-2">
            <h2>Payment Details</h2>
            <Button onClick={() => {navigate("addCard")}}>Add New Card</Button>
        </div>
        <Table>
            <thead>
                <tr>
                    <th>#</th>
                    <th>Name</th>
                    <th>Card Number</th>
                    <th>Card Expiration Date</th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {paymentDetails?.map((p, index) => (
                    <tr key={p.id}>
                        <th scope="row">{index +1}</th>
                        <td>{p.userProfile.fullName}</td>
                        <td>{p.creditCardNumber}</td>
                        <td>{p.creditCardExpiration}</td>
                        <td><Button onClick={() => {navigate(`${p.id}`)}}>Edit</Button></td>
                        <td><Button>Remove</Button></td>
                    </tr>
                ))}
            </tbody>
        </Table>
        </div>
    )
}