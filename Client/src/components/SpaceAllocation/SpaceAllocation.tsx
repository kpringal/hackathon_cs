import React, { FC } from 'react';
import styles from './SpaceAllocation.module.css';

interface SpaceAllocationProps {}

const SpaceAllocation: FC<SpaceAllocationProps> = () => (
  <div className={styles.SpaceAllocation} data-testid="SpaceAllocation">
    SpaceAllocation Component
  </div>
);

export default SpaceAllocation;
