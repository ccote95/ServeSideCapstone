import { useParams } from "react-router-dom"
import PageContainer from "../PageContainer.jsx"
import { Card, CardBody } from "reactstrap"

export default function ListingDetails()
{
    const {id} = useParams
    return(
       <PageContainer>
            <Card>
                <CardBody>
                    hello
                </CardBody>
            </Card>
       </PageContainer>
    )
}