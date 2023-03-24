import { Grid, Card, CardMedia, CardContent, Typography} from '@mui/material'
import { Link } from 'react-router-dom'
import { Category } from '../types/category'
import { v4 as uuidv4 } from 'uuid';

import { Image } from '../types/Image'

export interface ProductInterface {
  
    id: number
    title: string
    description: string
    price: number
    category: Category
    images:Image[]
}

const MapProducts = (product: ProductInterface) => {
    const cardOnHover = {
        transition: "transform 1s ease ",
        overflow: 'hidden',
        ":hover": {
            transform: 'scale(0.95)',
        }
    }

    return (
        <Grid key={uuidv4()} item xs={6} md={2} sx={cardOnHover} >
            <Card sx={{ cursor: 'pointer' }}>
                <Link to={`/products/${product.id}`} > <CardMedia
                    sx={{ height: 200 }}
                    image={product.images[0].url}
                /></Link>
                <CardContent>
                    <Typography variant='h6' gutterBottom noWrap >
                        {product.title}
                    </Typography>

                    <Typography variant='body2' fontWeight={'bold'} color="text.secondary">
                        € {product.price}
                    </Typography>
                </CardContent>
                {/* <CardActions>
                <Button onClick={() => addToCart(product)} variant='contained'> Add To Cart </Button>
              </CardActions> */}
            </Card>

        </Grid>
    )
}

export default MapProducts