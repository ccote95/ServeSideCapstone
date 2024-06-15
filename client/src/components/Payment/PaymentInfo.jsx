import { useNavigate } from "react-router-dom";
import { Button, Table } from "reactstrap";

export default function PaymentInfo()
{
    const navigate = useNavigate()

    return(
    <div>
        <div className="d-flex justify-content-between align-items-center mt-2 mb-3 me-2">
            <h2>Payment Details</h2>
            <Button onClick={() => {navigate("addCard")}}>Add New Card</Button>
        </div>
        <Table>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Card Number</th>
                    <th>Card Expiration Date</th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody></tbody>
        </Table>
        </div>
    )
}