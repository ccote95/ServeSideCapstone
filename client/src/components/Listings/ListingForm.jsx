import { Button, Dropdown, DropdownToggle, Form, FormGroup, Input, Label } from "reactstrap";
import PageContainer from "../PageContainer.jsx";
import { useState } from "react";

export default function ListingForm()
{
    const [dropDownOpen, setDropDownOpen] = useState(false)
    return (
      
   <PageContainer>
        <Form>
        <FormGroup>
            <Label>
                Title
            </Label>
            <Input
            placeholder="Enter the Title for the Listing"
            style={{width: "100%"}}
            />
        </FormGroup>
        <FormGroup>
            <Label>Category</Label>
            <Input
            type="select"
            />
        </FormGroup>
        <FormGroup>
            <Label>Price</Label>
            <Input/>
        </FormGroup>
        <FormGroup>
            <Label>Content</Label>
            <Input/>
        </FormGroup>
        <FormGroup>
            <Label>Image</Label>
            <Input
            type="file"/>
        </FormGroup>
        <Button style={{float: "right"}} color="primary">
            Post
        </Button>
       </Form>
   </PageContainer>
      
    )
}