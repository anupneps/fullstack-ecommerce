import { Box, Fab, Grid } from '@mui/material'
import { useEffect } from 'react'
import { useAppDispatch, useAppSelector } from '../hooks/reduxHook'
import AddTwoToneIcon from '@mui/icons-material/AddTwoTone';

import { fetchAllProducts } from '../redux/reducers/productReducer'
import { Product } from '../types/product';
import MapProducts from './MapProducts';
import DividerComponent from './Divider';
import { Link } from 'react-router-dom'


const Products = () => {
  const dispatch = useAppDispatch()
  const products = useAppSelector(state => state.productReducer)
  const featuredProductsList = products.slice(0, 12)
  // const recommondedProductsList = products.slice(45, 57)

  useEffect(() => {
    dispatch(fetchAllProducts())
  }, [dispatch])

  const renderProduct = (product: Product) => {
    return (
      <MapProducts
        key={product.id}
        id={product.id}
        title={product.title}
        images={product.images}
        price={product.price}
        description={product.description}
        category={product.category}
      />
    )
  }
  const boxLayout = {
    display: 'flex',
    justifyContent: 'center',
    justifySelf:'flex-end',
    marginTop: '30px',
    padding: '5px',
    width: '100%',
   
   
  }
  const hover ={
 backgroundColor: '#A88D5C',
    ":hover": {
      backgroundColor: '#FFC108'
    }
  }

  return (
    <>
      <DividerComponent title={'Featured Products'} />
      <Grid container spacing={2} width={'auto'} height={'auto'} margin={'30px'} marginTop={'10px'}>
        {featuredProductsList.map(renderProduct)}
        <Box sx={boxLayout} > <Link to='/categories'><Fab sx={hover} color="primary" aria-label="More">
          <AddTwoToneIcon />
        </Fab></Link> </Box>
      </Grid>

      {/* <DividerComponent title={'Recommended Products'} />
      <Grid container spacing={2} width={'auto'} margin={'30px'} marginTop={'10px'}>
        {(recommondedProductsList).map(renderProduct)}
        <Box sx={boxLayout} > <Link to='/categories'><Fab sx={hover} color="primary" aria-label="More">
          <AddTwoToneIcon />
        </Fab></Link> </Box>
      </Grid> */}
    </>
  )
}

export default Products