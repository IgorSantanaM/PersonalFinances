import React from 'react';
import { MdNavigateNext } from 'react-icons/md';
import {GrFormPrevious } from 'react-icons/gr';
import { GiWallet, } from 'react-icons/gi';
import { FaTags } from "react-icons/fa6";

import {Header, Title, IconWrapper, Previous, Next} from '../Component/Header/styles';
import { Container, StepButton} from '../Component/Container/styles';


export default function StepCategory() {
  return (
    <>
      <Header>
        <Previous to="/step/account">
              <GrFormPrevious  size={25} color="black" />
              <p>Previous</p>
        </Previous>
        <div>
          <IconWrapper>
              <GiWallet size={26} color="green" />
          </IconWrapper>
          <Title>Categories</Title>
         </div>
        <Next to="/step/reminder">
          <MdNavigateNext size={25} color="black" />
          <p>Next</p>
        </Next>
        </Header>
                
        <Container>
          <p>If you wish, you can add new categories and subcategories in each account.</p>
          <StepButton to="/categories">
            <button><FaTags size={26} color="black"  /> <strong> Categories</strong> </button>
            <p>Click here to go to the categories page!</p>
          </StepButton>
          <p>Use the account selector located at the top of screen to configure each account.</p>
          <h3> Finally! the reminders! Click the next to create your payment calendar.</h3>
      </ Container>
    </>

  )
}
