import { useEffect, useState } from "react";
import { getAllCartsById } from "../../managers/shoppingCartManager.js";
import { Badge } from "reactstrap";

export default function ShoppingCartCount({count})
{
  
    return(
        <div style={{ position: 'relative', display: 'inline-block' }}>
        <span role="img" aria-label="shopping cart"  style={{ fontSize: '24px', position: "relative", zIndex: "1" }}>🛒</span>
        {count > 0 && (
          <Badge color="danger" pill style={{
            position: 'absolute',
            top: '-5px',
            right: '8px',
            backgroundColor: 'red',
            color: 'white',
            borderRadius: '50%',
            padding: '0.3em 0.6em',
            fontSize: '0.75em'
          }}>
            {count}
          </Badge>
        )}
      </div>
    )
}