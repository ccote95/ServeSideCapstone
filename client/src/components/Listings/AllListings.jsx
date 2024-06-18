import { useEffect, useState } from "react"
import { getAll } from "../../managers/listingManger.js"
import { Button, Card, CardBody, CardImg, CardLink, CardSubtitle, CardText, CardTitle, Input } from "reactstrap"
import FlexContainer from "../FlexContainer.jsx"
import { useNavigate } from "react-router-dom"
import { getAllCategories } from "../../managers/categoryManager.js"

export default function AllListings()
{
    const [listings, setListings] = useState([])
    const [categories, setCategories] = useState([])
    const [categoryId, setCategoryId] = useState(0)
    const [filteredListings, setFilteredListings] = useState()

    const navigate = useNavigate()

    


    useEffect(() => {
        getAll().then(data => {
            setListings(data);
            setFilteredListings(data);
        })
        getAllCategories().then(setCategories)

    },[])

    useEffect(() => {
        if (categoryId === 0) {
            setFilteredListings(listings);
        } else {
            const filtered = listings.filter(l => {
                const categoryIds = l.categories.map(cat => cat.id); // Extract category IDs
                const includesCategory = categoryIds.includes(categoryId);
                return includesCategory;
            });
            setFilteredListings(filtered);
        }
    }, [categoryId, listings]);

    const handleCategoryChange = (e) => {
        setCategoryId(parseInt(e.target.value));
    };

    return (
        <div>
            <Button className="ms-2 mt-2" color="primary" onClick={() => {navigate("create")}}>
                New Listing
            </Button>
            <Input
            style={{width: "10%", float:"right"}}
            className="mt-2 me-2"
                type="select"
                value={categoryId}
                onChange={handleCategoryChange}
            >
            <option value={0} key={"c-0"}>Chose a Category</option>
            {categories.map(c => (
                <option value={c.id} key={c.id}>{c.name}</option>
            ))}
            </Input>
            <FlexContainer>
            {filteredListings?.map((l) => (
                <Card className="w-25 d-flex flex-column  shadow" key={l.id} style={{maxWidth: "1200px"}}>
                    <CardLink href={`listings/${l.id}`}>
                    {!l.imageBlob ? (
                    <CardImg
                        className="mt-1"
                        src={l.productImg}
                       style={{ height: "200px", objectFit: "contain" }}
                    />
                ) : (
                    <CardImg 
                    src={`data:image/jpeg;base64,${l.imageBlob}`}
                    style={{ height: "200px", objectFit: "contain" }} 
                    className="mt-1"
                    />
                )}
                    </CardLink>
                    <CardBody>
                        <CardTitle title={l.title} className="m-1 fs-1 fw-bold text-truncate" >
                            {l.title}
                        </CardTitle>
                    <CardText className="m-1 fs-2">
                        ${l.price}
                    </CardText>
                    </CardBody>
                </Card>
            ))}
            </FlexContainer>
        </div>
    )
}
