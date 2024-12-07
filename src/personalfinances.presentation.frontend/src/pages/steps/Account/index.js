import React from 'react';
import { MdNavigateNext} from "react-icons/md";
import {GrFormPrevious } from 'react-icons/gr';
import { GiWallet, } from "react-icons/gi";
import {Link} from 'react-router-dom'

import {Header, Title, IconWrapper} from '../Component/Header/styles';
import {  Container} from './styles';


export default function StepAccount() {
  return (
    <>

      <Header>
        <Link to="/" style={{ textDecoration: 'none' }}>
              <GrFormPrevious size={25} color="black" />
              <p>Previous</p>
        </Link>
          <IconWrapper>
              <GiWallet size={26} color="green" />
          </IconWrapper>
          <Title>Accounts</Title>
          <Link to="/step/category" style={{ textDecoration: 'none' }}>
              <MdNavigateNext size={25} color="black" />
              <p>Next</p>
          </Link>
        </Header>
                
      <Container>

      </ Container>
    </>

  )
}
