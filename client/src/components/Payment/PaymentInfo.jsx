import { Table } from "reactstrap";

export default function PaymentInfo()
{
    return(
        <Table>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Card Number</th>
                    <th>Card Expiration Date</th>
                </tr>
            </thead>
            <tbody></tbody>
        </Table>
    )
}