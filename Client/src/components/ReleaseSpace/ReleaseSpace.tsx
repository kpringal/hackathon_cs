import React, { FC } from 'react';
import styles from './ReleaseSpace.module.css';

interface ReleaseSpaceProps {}

const ReleaseSpace: FC<ReleaseSpaceProps> = () => (
  <div className={styles.Delete} data-testid="ReleaseSpace">
    All request for freeing space are coming here!
  </div>
);

export default ReleaseSpace;
