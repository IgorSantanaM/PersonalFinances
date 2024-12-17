import React from 'react';
import { MdNavigateNext, MdAccountBalance} from "react-icons/md";
import {GrFormPrevious } from 'react-icons/gr';
import { GiWallet, } from "react-icons/gi";

import {Header, Title, IconWrapper, Next, Previous} from '../Component/Header/styles';
import { Container, StepButton} from '../Component/Container/styles';


export default function StepAccount() {
  return (
    <>
      <Header>
        <Previous to="/" style={{ textDecoration: 'none' }}>
              <GrFormPrevious size={25} color="black" />
              <p>Previous</p>
        </Previous>
        <div>
          <IconWrapper>
              <GiWallet size={26} color="green" />
          </IconWrapper>
          <Title>Accounts</Title>
        </div>
          <Next to="/step/category">
              <MdNavigateNext size={25} color="black" />
              <p>Next</p>
          </Next>
        </Header>
                
      <Container>
          <p>Your first step is to register all your bank accounts, cards, saving, etc.</p>
          <StepButton to="/account">
            <button><MdAccountBalance size={26} color="black"  /> <strong> Accounts</strong> </button>
            <p>Click here to go to the accounts page!</p>
          </StepButton>
          <p>When creating each account, you can select default categories to use with that account.</p>
          <h3> Once you have your accounts ready, click next to go to set up your categories and subcategories!</h3>
      </ Container>
    </>

  )
}
