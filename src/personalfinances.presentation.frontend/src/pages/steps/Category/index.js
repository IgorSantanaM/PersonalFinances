import React from 'react';
import { MdNavigateNext } from 'react-icons/md';
import {GrFormPrevious } from 'react-icons/gr';
import { GiWallet, } from 'react-icons/gi';
import {Link} from 'react-router-dom'

import {Header, Title, IconWrapper} from '../Component/Header/styles';
import { Container} from './styles'


export default function StepCategory() {
  return (
    <>
      <Header>
      <Link to="/step/account" style={{ textDecoration: 'none' }}>
             <GrFormPrevious  size={25} color="black" />
             <p>Previous</p>
          </Link>
         <IconWrapper>
            <GiWallet size={26} color="green" />
         </IconWrapper>
         <Title>Categories</Title>
         <Link to="/step/reminder" style={{ textDecoration: 'none' }}>
             <MdNavigateNext size={25} color="black" />
             <p>Next</p>
          </Link>
        </Header>
                
      <Container>

      </ Container>
    </>

  )
}
